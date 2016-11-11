﻿// Copyright 2015 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Api.Gax;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Google.Storage.V1
{
    /// <summary>
    /// Class which helps create signed URLs which can be used to provide limited access to specific buckets and objects
    /// to anyone in possession of the URL, regardless of whether they have a Google account.
    /// </summary>
    /// <remarks>
    /// See https://cloud.google.com/storage/docs/access-control/signed-urls for more information on signed URLs.
    /// </remarks>
    public static class SignedUrlUtils
    {
        private const string GoogHeaderPrefix = "x-goog-";
        private const string GoogEncryptionKeyHeader = "x-goog-encryption-key";
        private const string GoogEncryptionKeySHA256Header = "x-goog-encryption-key-sha256";
        private const string StorageHost = "https://storage.googleapis.com";
        private static readonly DateTimeOffset UnixEpoch = new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), TimeSpan.Zero);

        /// <summary>
        /// Creates a signed URL which can be used to provide limited access to specific buckets and objects to anyone
        /// in possession of the URL, regardless of whether they have a Google account.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the <paramref name="request"/> is specified, some of its headers will be included in the signed URL's
        /// signature, and therefore must be included in requests made with the created URL. These are the Content-MD5 and
        /// Content-Type content headers as well as any content or request header with a name starting with "x-goog-".
        /// </para>
        /// <para>
        /// If <paramref name="request"/> is null, no headers are included in the signed URL's signature, so any requests
        /// made with the created URL must not contain Content-MD5, Content-Type, or any header starting with "x-goog-".
        /// </para>
        /// <para>
        /// Note that if the entity is encrypted with customer-supplied encryption keys (see
        /// https://cloud.google.com/storage/docs/encryption for more information), the <b>x-goog-encryption-algorithm</b>,
        /// <b>x-goog-encryption-key</b>, and <b>x-goog-encryption-key-sha256</b> headers will be required when making the
        /// request. However, only the x-goog-encryption-algorithm header is included in the signature for the signed URL.
        /// So the sample <paramref name="request"/> specified only needs to have the x-goog-encryption-algorithm request
        /// header. The other headers can be included, but will be ignored.
        /// </para>
        /// <para>
        /// Note that when GET is specified as the <paramref name="request"/>, both GET and HEAD requests can be made with
        /// the created signed URL.
        /// </para>
        /// <para>
        /// See https://cloud.google.com/storage/docs/access-control/signed-urls for more information on signed URLs.
        /// </para>
        /// </remarks>
        /// <param name="bucket">The name of the bucket. Must not be null.</param>
        /// <param name="objectName">The name of the object within the bucket. May be null, in which case the signed URL
        /// will refer to the bucket instead of an object.</param>
        /// <param name="credentialFilePath">The path to the JSON key file for a service account. Must not be null.</param>
        /// <param name="duration">The length of time for which the signed URL should remain usable.</param>
        /// <param name="request">A sample request for which the signed URL might be used. May be null.</param>
        /// <exception cref="InvalidOperationException">
        /// The <paramref name="credentialFilePath"/> does not refer to a valid JSON service account key file.
        /// </exception>
        /// <returns>
        /// The signed URL which can be used to provide access to a bucket or object for a limited amount of time.
        /// </returns>
        public static string Create(
            string bucket,
            string objectName,
            string credentialFilePath,
            TimeSpan duration,
            HttpRequestMessage request) =>
                Create(bucket, objectName, credentialFilePath, DateTimeOffset.UtcNow + duration, request);

        /// <summary>
        /// Creates a signed URL which can be used to provide limited access to specific buckets and objects to anyone
        /// in possession of the URL, regardless of whether they have a Google account.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When the <paramref name="request"/> is specified, some of its headers will be included in the signed URL's
        /// signature, and therefore must be included in requests made with the created URL. These are the Content-MD5 and
        /// Content-Type content headers as well as any content or request header with a name starting with "x-goog-".
        /// </para>
        /// <para>
        /// If <paramref name="request"/> is null, no headers are included in the signed URL's signature, so any requests
        /// made with the created URL must not contain Content-MD5, Content-Type, or any header starting with "x-goog-".
        /// </para>
        /// <para>
        /// Note that if the entity is encrypted with customer-supplied encryption keys (see
        /// https://cloud.google.com/storage/docs/encryption for more information), the <b>x-goog-encryption-algorithm</b>,
        /// <b>x-goog-encryption-key</b>, and <b>x-goog-encryption-key-sha256</b> headers will be required when making the
        /// request. However, only the x-goog-encryption-algorithm header is included in the signature for the signed URL.
        /// So the sample <paramref name="request"/> specified only needs to have the x-goog-encryption-algorithm request
        /// header. The other headers can be included, but will be ignored.
        /// </para>
        /// <para>
        /// Note that when GET is specified as the <paramref name="request"/>, both GET and HEAD requests can be made with
        /// the created signed URL.
        /// </para>
        /// <para>
        /// See https://cloud.google.com/storage/docs/access-control/signed-urls for more information on signed URLs.
        /// </para>
        /// </remarks>
        /// <param name="bucket">The name of the bucket. Must not be null.</param>
        /// <param name="objectName">The name of the object within the bucket. May be null, in which case the signed URL
        /// will refer to the bucket instead of an object.</param>
        /// <param name="credentialFilePath">The path to the JSON key file for a service account. Must not be null.</param>
        /// <param name="expiration">The point in time after which the signed URL will be invalid. May be null, in which
        /// case the signed URL never expires.</param>
        /// <param name="request">A sample request for which the signed URL might be used. May be null.</param>
        /// <exception cref="InvalidOperationException">
        /// The <paramref name="credentialFilePath"/> does not refer to a valid JSON service account key file.
        /// </exception>
        /// <returns>
        /// The signed URL which can be used to provide access to a bucket or object for a limited amount of time.
        /// </returns>
        public static string Create(
            string bucket,
            string objectName,
            string credentialFilePath,
            DateTimeOffset? expiration,
            HttpRequestMessage request) =>
                Create(
                    bucket,
                    objectName,
                    credentialFilePath,
                    expiration,
                    request?.Method,
                    request?.Headers?.ToDictionary(h => h.Key, h => h.Value),
                    request?.Content?.Headers?.ToDictionary(h => h.Key, h => h.Value));

        /// <summary>
        /// Creates a signed URL which can be used to provide limited access to specific buckets and objects to anyone
        /// in possession of the URL, regardless of whether they have a Google account.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When either of the headers collections are specified, there are certain headers which will be included in the
        /// signed URL's signature, and therefore must be included in requests made with the created URL. These are the
        /// Content-MD5 and Content-Type content headers as well as any content or request header with a name starting
        /// with "x-goog-".
        /// </para>
        /// <para>
        /// If the headers collections are null or empty, no headers are included in the signed URL's signature, so any
        /// requests made with the created URL must not contain Content-MD5, Content-Type, or any header starting with "x-goog-".
        /// </para>
        /// <para>
        /// Note that if the entity is encrypted with customer-supplied encryption keys (see
        /// https://cloud.google.com/storage/docs/encryption for more information), the <b>x-goog-encryption-algorithm</b>,
        /// <b>x-goog-encryption-key</b>, and <b>x-goog-encryption-key-sha256</b> headers will be required when making the
        /// request. However, only the x-goog-encryption-algorithm header is included in the signature for the signed URL.
        /// So the <paramref name="requestHeaders"/> specified only need to have the x-goog-encryption-algorithm header.
        /// The other headers can be included, but will be ignored.
        /// </para>
        /// <para>
        /// Note that when GET is specified as the <paramref name="requestMethod"/> (or it is null, in which case GET is
        /// used), both GET and HEAD requests can be made with the created signed URL.
        /// </para>
        /// <para>
        /// See https://cloud.google.com/storage/docs/access-control/signed-urls for more information on signed URLs.
        /// </para>
        /// </remarks>
        /// <param name="bucket">The name of the bucket. Must not be null.</param>
        /// <param name="objectName">The name of the object within the bucket. May be null, in which case the signed URL
        /// will refer to the bucket instead of an object.</param>
        /// <param name="credentialFilePath">The path to the JSON key file for a service account. Must not be null.</param>
        /// <param name="duration">The length of time for which the signed URL should remain usable.</param>
        /// <param name="requestMethod">The HTTP request method for which the signed URL is allowed to be used. May be null,
        /// in which case GET will be used.</param>
        /// <param name="requestHeaders">The headers which will be included with the request. May be null.</param>
        /// <param name="contentHeaders">The headers for the content which will be included with the request.
        /// May be null.</param>
        /// <exception cref="InvalidOperationException">
        /// The <paramref name="credentialFilePath"/> does not refer to a valid JSON service account key file.
        /// </exception>
        /// <returns>
        /// The signed URL which can be used to provide access to a bucket or object for a limited amount of time.
        /// </returns>
        public static string Create(
            string bucket,
            string objectName,
            string credentialFilePath,
            TimeSpan duration,
            HttpMethod requestMethod = null,
            Dictionary<string, IEnumerable<string>> requestHeaders = null,
            Dictionary<string, IEnumerable<string>> contentHeaders = null) =>
                Create(
                    bucket,
                    objectName,
                    credentialFilePath,
                    DateTimeOffset.UtcNow + duration,
                    requestMethod,
                    requestHeaders,
                    contentHeaders);

        /// <summary>
        /// Creates a signed URL which can be used to provide limited access to specific buckets and objects to anyone
        /// in possession of the URL, regardless of whether they have a Google account.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When either of the headers collections are specified, there are certain headers which will be included in the
        /// signed URL's signature, and therefore must be included in requests made with the created URL. These are the
        /// Content-MD5 and Content-Type content headers as well as any content or request header with a name starting
        /// with "x-goog-".
        /// </para>
        /// <para>
        /// If the headers collections are null or empty, no headers are included in the signed URL's signature, so any
        /// requests made with the created URL must not contain Content-MD5, Content-Type, or any header starting with "x-goog-".
        /// </para>
        /// <para>
        /// Note that if the entity is encrypted with customer-supplied encryption keys (see
        /// https://cloud.google.com/storage/docs/encryption for more information), the <b>x-goog-encryption-algorithm</b>,
        /// <b>x-goog-encryption-key</b>, and <b>x-goog-encryption-key-sha256</b> headers will be required when making the
        /// request. However, only the x-goog-encryption-algorithm header is included in the signature for the signed URL.
        /// So the <paramref name="requestHeaders"/> specified only need to have the x-goog-encryption-algorithm header.
        /// The other headers can be included, but will be ignored.
        /// </para>
        /// <para>
        /// Note that when GET is specified as the <paramref name="requestMethod"/> (or it is null, in which case GET is
        /// used), both GET and HEAD requests can be made with the created signed URL.
        /// </para>
        /// <para>
        /// See https://cloud.google.com/storage/docs/access-control/signed-urls for more information on signed URLs.
        /// </para>
        /// </remarks>
        /// <param name="bucket">The name of the bucket. Must not be null.</param>
        /// <param name="objectName">The name of the object within the bucket. May be null, in which case the signed URL
        /// will refer to the bucket instead of an object.</param>
        /// <param name="credentialFilePath">The path to the JSON key file for a service account. Must not be null.</param>
        /// <param name="expiration">The point in time after which the signed URL will be invalid. May be null, in which
        /// case the signed URL never expires.</param>
        /// <param name="requestMethod">The HTTP request method for which the signed URL is allowed to be used. May be null,
        /// in which case GET will be used.</param>
        /// <param name="requestHeaders">The headers which will be included with the request. May be null.</param>
        /// <param name="contentHeaders">The headers for the content which will be included with the request.
        /// May be null.</param>
        /// <exception cref="InvalidOperationException">
        /// The <paramref name="credentialFilePath"/> does not refer to a valid JSON service account key file.
        /// </exception>
        /// <returns>
        /// The signed URL which can be used to provide access to a bucket or object for a limited amount of time.
        /// </returns>
        public static string Create(
            string bucket,
            string objectName,
            string credentialFilePath,
            DateTimeOffset? expiration,
            HttpMethod requestMethod = null,
            Dictionary<string, IEnumerable<string>> requestHeaders = null,
            Dictionary<string, IEnumerable<string>> contentHeaders = null)
        {
            StorageClientImpl.ValidateBucketName(bucket);
            GaxPreconditions.CheckNotNull(credentialFilePath, nameof(credentialFilePath));

            var credentials = ParseCredentials(credentialFilePath);
            var expiryUnixSeconds = ((int?)((expiration - UnixEpoch)?.TotalSeconds))?.ToString(CultureInfo.InvariantCulture);
            var resourcePath = $"/{bucket}";
            if (objectName != null)
            {
                resourcePath += $"/{objectName}";
            }
            var extensionHeaders = GetExtensionHeaders(requestHeaders, contentHeaders);

            var contentMD5 = GetFirstHeaderValue(contentHeaders, "Content-MD5");
            var contentType = GetFirstHeaderValue(contentHeaders, "Content-Type");

            var signatureLines = new List<string>
            {
                (requestMethod ?? HttpMethod.Get).ToString(),
                contentMD5,
                contentType,
                expiryUnixSeconds
            };
            signatureLines.AddRange(extensionHeaders.Select(
                header => $"{header.Key}:{string.Join(", ", header.Value)}"));
            signatureLines.Add(resourcePath);

            var signature = CreateSignature(string.Join("\n", signatureLines), credentials);

            var queryParameters = new List<string> { $"GoogleAccessId={credentials.Id}" };
            if (expiryUnixSeconds != null)
            {
                queryParameters.Add($"Expires={expiryUnixSeconds}");
            }
            queryParameters.Add($"Signature={signature}");
            return $"{StorageHost}{resourcePath}?{string.Join("&", queryParameters)}";
        }

        private static string CreateSignature(string data, ServiceAccountCredential.Initializer initializer)
        {
            // TODO: This is taken from ServiceAccountCredential. Expose this somehow so we don't need to duplicate logic.
            using (var hashAlg = SHA256.Create())
            {
                byte[] assertionHash = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(data));
#if NETSTANDARD1_3
            var sigBytes = initializer.Key.SignHash(assertionHash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
#else
                const string Sha256Oig = "2.16.840.1.101.3.4.2.1";
                var sigBytes = initializer.Key.SignHash(assertionHash, Sha256Oig);
#endif
                return WebUtility.UrlEncode(Convert.ToBase64String(sigBytes));
            }
        }

        private static SortedDictionary<string, StringBuilder> GetExtensionHeaders(
            Dictionary<string, IEnumerable<string>> requestHeaders,
            Dictionary<string, IEnumerable<string>> contentHeaders)
        {
            // These docs indicate how to include extension headers in the signature, but they're not exactly
            // correct (values must be trimmed, newlines are replaced with empty strings, not whitespace, and
            // values are concatenated with ", " instead of ",", but not when joining request and content headers).
            // https://cloud.google.com/storage/docs/access-control/signed-urls#about-canonical-extension-headers
            var extensionHeaders = new SortedDictionary<string, StringBuilder>();

            if (requestHeaders != null)
            {
                PopulateExtensionHeaders(requestHeaders, extensionHeaders);
            }

            if (contentHeaders != null)
            {
                PopulateExtensionHeaders(
                    contentHeaders,
                    extensionHeaders,
                    keysToExcludeSpaceInNextValueSeparator: new HashSet<string>(extensionHeaders.Keys));
            }

            return extensionHeaders;
        }

        private static void PopulateExtensionHeaders(
            Dictionary<string, IEnumerable<string>> headers,
            SortedDictionary<string, StringBuilder> extensionHeaders,
            HashSet<string> keysToExcludeSpaceInNextValueSeparator = null)
        {
            foreach (var header in headers)
            {
                var key = header.Key.ToLowerInvariant();
                if (!key.StartsWith(GoogHeaderPrefix) ||
                    key == GoogEncryptionKeyHeader ||
                    key == GoogEncryptionKeySHA256Header)
                {
                    continue;
                }

                StringBuilder values;
                if (!extensionHeaders.TryGetValue(key, out values))
                {
                    values = new StringBuilder();
                    extensionHeaders.Add(key, values);
                }
                else
                {
                    if (keysToExcludeSpaceInNextValueSeparator == null ||
                        !keysToExcludeSpaceInNextValueSeparator.Remove(key))
                    {
                        values.Append(' ');
                    }
                    values.Append(',');
                }

                values.Append(string.Join(", ",
                    header.Value.Select(s => s.Trim().Replace("\r\n", "").Replace("\n", ""))));
            }
        }

        private static string GetFirstHeaderValue(Dictionary<string, IEnumerable<string>> contentHeaders, string name)
        {
            IEnumerable<string> values;
            if (contentHeaders != null && contentHeaders.TryGetValue(name, out values))
            {
                return values.FirstOrDefault();
            }
            return null;
        }

        private static ServiceAccountCredential.Initializer ParseCredentials(string credentialFilePath)
        {
            var credentialParameters = ParseCredentialParameters(credentialFilePath);
            return new ServiceAccountCredential.Initializer(credentialParameters.ClientEmail)
                .FromPrivateKey(credentialParameters.PrivateKey);
        }

        private static JsonCredentialParameters ParseCredentialParameters(string credentialFilePath)
        {
            // TODO: This is taken from two places in DefaultCredentialProvider. Expose those pieces so we don't need to duplicate logic.
            JsonCredentialParameters credentialParameters;
            try
            {
                using (var credentialStream = File.OpenRead(credentialFilePath))
                {
                    credentialParameters = NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(credentialStream);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error deserializing JSON credential data.", e);
            }

            if (credentialParameters.Type != JsonCredentialParameters.ServiceAccountCredentialType ||
                string.IsNullOrEmpty(credentialParameters.ClientEmail) ||
                string.IsNullOrEmpty(credentialParameters.PrivateKey))
            {
                throw new InvalidOperationException("JSON data does not represent a valid service account credential.");
            }

            return credentialParameters;
        }
    }
}
