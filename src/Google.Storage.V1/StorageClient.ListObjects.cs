﻿// Copyright 2015 Google Inc. All Rights Reserved.
// Licensed under the Apache License Version 2.0.

using Google.Apis.Requests;
using Google.Apis.Storage.v1;
using Google.Apis.Storage.v1.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Object = Google.Apis.Storage.v1.Data.Object;

namespace Google.Storage.V1
{
    // ListObjects methods on StorageClient
    public partial class StorageClient
    {
        private static readonly PageStreamer<Object, ObjectsResource.ListRequest, Objects, string> s_objectPageStreamer =
            new PageStreamer<Object, ObjectsResource.ListRequest, Objects, string>(
                (request, token) => request.PageToken = token,
                objects => objects.NextPageToken,
                objects => objects.Items);

        /// <summary>
        /// Asynchronously lists the objects in a given bucket, returning the results as a list.
        /// </summary>
        /// <remarks>
        /// This lists the objects within a bucket before the returned task completes.
        /// This does not support reporting progress, or streaming the results.
        /// </remarks>
        /// <param name="bucket">The bucket to list the objects from. Must not be null.</param>
        /// <param name="prefix">The prefix to match. Only objects with names that start with this string will be returned.
        /// This parameter may be null, in which case no filtering is performed.</param>
        /// <param name="options">The options for the operation. May be null, in which case
        /// defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A list of objects within the bucket.</returns>
        public Task<IList<Object>> ListAllObjectsAsync(
            string bucket,
            string prefix,
            ListObjectsOptions options = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var initialRequest = CreateListObjectsRequest(bucket, prefix, options);
            return s_objectPageStreamer.FetchAllAsync(initialRequest, cancellationToken);
        }


        /// <summary>
        /// Lists the objects in a given bucket, synchronously but lazily.
        /// </summary>
        /// <remarks>
        /// This method fetches the objects lazily, making requests to the underlying service
        /// for a page of results at a time, as required. To retrieve all the objects in a single collection,
        /// simply call LINQ's <c>ToList()</c> method on the returned sequence.
        /// </remarks>
        /// <param name="bucket">The bucket to list the objects from. Must not be null.</param>
        /// <param name="prefix">The prefix to match. Only objects with names that start with this string will be returned.
        /// This parameter may be null, in which case no filtering is performed.</param>
        /// <param name="options">The options for the operation. May be null, in which case
        /// defaults will be supplied.</param>
        /// <returns>A sequence of objects within the bucket.</returns>
        public IEnumerable<Object> ListObjects(string bucket, string prefix, ListObjectsOptions options = null)
        {
            var initialRequest = CreateListObjectsRequest(bucket, prefix, options);
            return s_objectPageStreamer.Fetch(initialRequest);
        }

        private ObjectsResource.ListRequest CreateListObjectsRequest(string bucket, string prefix, ListObjectsOptions options)
        {
            ValidateBucket(bucket);
            var request = Service.Objects.List(bucket);
            request.Prefix = prefix;
            options?.ModifyRequest(request);
            return request;
        }
    }
}
