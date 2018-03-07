// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/firestore/v1beta1/common.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Cloud.Firestore.V1Beta1 {

  /// <summary>Holder for reflection information generated from google/firestore/v1beta1/common.proto</summary>
  public static partial class CommonReflection {

    #region Descriptor
    /// <summary>File descriptor for google/firestore/v1beta1/common.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CommonReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiVnb29nbGUvZmlyZXN0b3JlL3YxYmV0YTEvY29tbW9uLnByb3RvEhhnb29n",
            "bGUuZmlyZXN0b3JlLnYxYmV0YTEaHGdvb2dsZS9hcGkvYW5ub3RhdGlvbnMu",
            "cHJvdG8aH2dvb2dsZS9wcm90b2J1Zi90aW1lc3RhbXAucHJvdG8iIwoMRG9j",
            "dW1lbnRNYXNrEhMKC2ZpZWxkX3BhdGhzGAEgAygJImUKDFByZWNvbmRpdGlv",
            "bhIQCgZleGlzdHMYASABKAhIABIxCgt1cGRhdGVfdGltZRgCIAEoCzIaLmdv",
            "b2dsZS5wcm90b2J1Zi5UaW1lc3RhbXBIAEIQCg5jb25kaXRpb25fdHlwZSKz",
            "AgoSVHJhbnNhY3Rpb25PcHRpb25zEkoKCXJlYWRfb25seRgCIAEoCzI1Lmdv",
            "b2dsZS5maXJlc3RvcmUudjFiZXRhMS5UcmFuc2FjdGlvbk9wdGlvbnMuUmVh",
            "ZE9ubHlIABJMCgpyZWFkX3dyaXRlGAMgASgLMjYuZ29vZ2xlLmZpcmVzdG9y",
            "ZS52MWJldGExLlRyYW5zYWN0aW9uT3B0aW9ucy5SZWFkV3JpdGVIABomCglS",
            "ZWFkV3JpdGUSGQoRcmV0cnlfdHJhbnNhY3Rpb24YASABKAwaUwoIUmVhZE9u",
            "bHkSLwoJcmVhZF90aW1lGAIgASgLMhouZ29vZ2xlLnByb3RvYnVmLlRpbWVz",
            "dGFtcEgAQhYKFGNvbnNpc3RlbmN5X3NlbGVjdG9yQgYKBG1vZGVCuQEKHGNv",
            "bS5nb29nbGUuZmlyZXN0b3JlLnYxYmV0YTFCC0NvbW1vblByb3RvUAFaQWdv",
            "b2dsZS5nb2xhbmcub3JnL2dlbnByb3RvL2dvb2dsZWFwaXMvZmlyZXN0b3Jl",
            "L3YxYmV0YTE7ZmlyZXN0b3JlogIER0NGU6oCHkdvb2dsZS5DbG91ZC5GaXJl",
            "c3RvcmUuVjFCZXRhMcoCHkdvb2dsZVxDbG91ZFxGaXJlc3RvcmVcVjFiZXRh",
            "MWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Api.AnnotationsReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Cloud.Firestore.V1Beta1.DocumentMask), global::Google.Cloud.Firestore.V1Beta1.DocumentMask.Parser, new[]{ "FieldPaths" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Cloud.Firestore.V1Beta1.Precondition), global::Google.Cloud.Firestore.V1Beta1.Precondition.Parser, new[]{ "Exists", "UpdateTime" }, new[]{ "ConditionType" }, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Cloud.Firestore.V1Beta1.TransactionOptions), global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Parser, new[]{ "ReadOnly", "ReadWrite" }, new[]{ "Mode" }, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadWrite), global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadWrite.Parser, new[]{ "RetryTransaction" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadOnly), global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadOnly.Parser, new[]{ "ReadTime" }, new[]{ "ConsistencySelector" }, null, null)})
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// A set of field paths on a document.
  /// Used to restrict a get or update operation on a document to a subset of its
  /// fields.
  /// This is different from standard field masks, as this is always scoped to a
  /// [Document][google.firestore.v1beta1.Document], and takes in account the dynamic nature of [Value][google.firestore.v1beta1.Value].
  /// </summary>
  public sealed partial class DocumentMask : pb::IMessage<DocumentMask> {
    private static readonly pb::MessageParser<DocumentMask> _parser = new pb::MessageParser<DocumentMask>(() => new DocumentMask());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DocumentMask> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Cloud.Firestore.V1Beta1.CommonReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DocumentMask() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DocumentMask(DocumentMask other) : this() {
      fieldPaths_ = other.fieldPaths_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DocumentMask Clone() {
      return new DocumentMask(this);
    }

    /// <summary>Field number for the "field_paths" field.</summary>
    public const int FieldPathsFieldNumber = 1;
    private static readonly pb::FieldCodec<string> _repeated_fieldPaths_codec
        = pb::FieldCodec.ForString(10);
    private readonly pbc::RepeatedField<string> fieldPaths_ = new pbc::RepeatedField<string>();
    /// <summary>
    /// The list of field paths in the mask. See [Document.fields][google.firestore.v1beta1.Document.fields] for a field
    /// path syntax reference.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> FieldPaths {
      get { return fieldPaths_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DocumentMask);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DocumentMask other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!fieldPaths_.Equals(other.fieldPaths_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= fieldPaths_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      fieldPaths_.WriteTo(output, _repeated_fieldPaths_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += fieldPaths_.CalculateSize(_repeated_fieldPaths_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DocumentMask other) {
      if (other == null) {
        return;
      }
      fieldPaths_.Add(other.fieldPaths_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            fieldPaths_.AddEntriesFrom(input, _repeated_fieldPaths_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// A precondition on a document, used for conditional operations.
  /// </summary>
  public sealed partial class Precondition : pb::IMessage<Precondition> {
    private static readonly pb::MessageParser<Precondition> _parser = new pb::MessageParser<Precondition>(() => new Precondition());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Precondition> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Cloud.Firestore.V1Beta1.CommonReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Precondition() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Precondition(Precondition other) : this() {
      switch (other.ConditionTypeCase) {
        case ConditionTypeOneofCase.Exists:
          Exists = other.Exists;
          break;
        case ConditionTypeOneofCase.UpdateTime:
          UpdateTime = other.UpdateTime.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Precondition Clone() {
      return new Precondition(this);
    }

    /// <summary>Field number for the "exists" field.</summary>
    public const int ExistsFieldNumber = 1;
    /// <summary>
    /// When set to `true`, the target document must exist.
    /// When set to `false`, the target document must not exist.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Exists {
      get { return conditionTypeCase_ == ConditionTypeOneofCase.Exists ? (bool) conditionType_ : false; }
      set {
        conditionType_ = value;
        conditionTypeCase_ = ConditionTypeOneofCase.Exists;
      }
    }

    /// <summary>Field number for the "update_time" field.</summary>
    public const int UpdateTimeFieldNumber = 2;
    /// <summary>
    /// When set, the target document must exist and have been last updated at
    /// that time.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp UpdateTime {
      get { return conditionTypeCase_ == ConditionTypeOneofCase.UpdateTime ? (global::Google.Protobuf.WellKnownTypes.Timestamp) conditionType_ : null; }
      set {
        conditionType_ = value;
        conditionTypeCase_ = value == null ? ConditionTypeOneofCase.None : ConditionTypeOneofCase.UpdateTime;
      }
    }

    private object conditionType_;
    /// <summary>Enum of possible cases for the "condition_type" oneof.</summary>
    public enum ConditionTypeOneofCase {
      None = 0,
      Exists = 1,
      UpdateTime = 2,
    }
    private ConditionTypeOneofCase conditionTypeCase_ = ConditionTypeOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ConditionTypeOneofCase ConditionTypeCase {
      get { return conditionTypeCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearConditionType() {
      conditionTypeCase_ = ConditionTypeOneofCase.None;
      conditionType_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Precondition);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Precondition other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Exists != other.Exists) return false;
      if (!object.Equals(UpdateTime, other.UpdateTime)) return false;
      if (ConditionTypeCase != other.ConditionTypeCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (conditionTypeCase_ == ConditionTypeOneofCase.Exists) hash ^= Exists.GetHashCode();
      if (conditionTypeCase_ == ConditionTypeOneofCase.UpdateTime) hash ^= UpdateTime.GetHashCode();
      hash ^= (int) conditionTypeCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (conditionTypeCase_ == ConditionTypeOneofCase.Exists) {
        output.WriteRawTag(8);
        output.WriteBool(Exists);
      }
      if (conditionTypeCase_ == ConditionTypeOneofCase.UpdateTime) {
        output.WriteRawTag(18);
        output.WriteMessage(UpdateTime);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (conditionTypeCase_ == ConditionTypeOneofCase.Exists) {
        size += 1 + 1;
      }
      if (conditionTypeCase_ == ConditionTypeOneofCase.UpdateTime) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(UpdateTime);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Precondition other) {
      if (other == null) {
        return;
      }
      switch (other.ConditionTypeCase) {
        case ConditionTypeOneofCase.Exists:
          Exists = other.Exists;
          break;
        case ConditionTypeOneofCase.UpdateTime:
          if (UpdateTime == null) {
            UpdateTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
          }
          UpdateTime.MergeFrom(other.UpdateTime);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Exists = input.ReadBool();
            break;
          }
          case 18: {
            global::Google.Protobuf.WellKnownTypes.Timestamp subBuilder = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            if (conditionTypeCase_ == ConditionTypeOneofCase.UpdateTime) {
              subBuilder.MergeFrom(UpdateTime);
            }
            input.ReadMessage(subBuilder);
            UpdateTime = subBuilder;
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// Options for creating a new transaction.
  /// </summary>
  public sealed partial class TransactionOptions : pb::IMessage<TransactionOptions> {
    private static readonly pb::MessageParser<TransactionOptions> _parser = new pb::MessageParser<TransactionOptions>(() => new TransactionOptions());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TransactionOptions> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Cloud.Firestore.V1Beta1.CommonReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TransactionOptions() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TransactionOptions(TransactionOptions other) : this() {
      switch (other.ModeCase) {
        case ModeOneofCase.ReadOnly:
          ReadOnly = other.ReadOnly.Clone();
          break;
        case ModeOneofCase.ReadWrite:
          ReadWrite = other.ReadWrite.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TransactionOptions Clone() {
      return new TransactionOptions(this);
    }

    /// <summary>Field number for the "read_only" field.</summary>
    public const int ReadOnlyFieldNumber = 2;
    /// <summary>
    /// The transaction can only be used for read operations.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadOnly ReadOnly {
      get { return modeCase_ == ModeOneofCase.ReadOnly ? (global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadOnly) mode_ : null; }
      set {
        mode_ = value;
        modeCase_ = value == null ? ModeOneofCase.None : ModeOneofCase.ReadOnly;
      }
    }

    /// <summary>Field number for the "read_write" field.</summary>
    public const int ReadWriteFieldNumber = 3;
    /// <summary>
    /// The transaction can be used for both read and write operations.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadWrite ReadWrite {
      get { return modeCase_ == ModeOneofCase.ReadWrite ? (global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadWrite) mode_ : null; }
      set {
        mode_ = value;
        modeCase_ = value == null ? ModeOneofCase.None : ModeOneofCase.ReadWrite;
      }
    }

    private object mode_;
    /// <summary>Enum of possible cases for the "mode" oneof.</summary>
    public enum ModeOneofCase {
      None = 0,
      ReadOnly = 2,
      ReadWrite = 3,
    }
    private ModeOneofCase modeCase_ = ModeOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ModeOneofCase ModeCase {
      get { return modeCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearMode() {
      modeCase_ = ModeOneofCase.None;
      mode_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TransactionOptions);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TransactionOptions other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(ReadOnly, other.ReadOnly)) return false;
      if (!object.Equals(ReadWrite, other.ReadWrite)) return false;
      if (ModeCase != other.ModeCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (modeCase_ == ModeOneofCase.ReadOnly) hash ^= ReadOnly.GetHashCode();
      if (modeCase_ == ModeOneofCase.ReadWrite) hash ^= ReadWrite.GetHashCode();
      hash ^= (int) modeCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (modeCase_ == ModeOneofCase.ReadOnly) {
        output.WriteRawTag(18);
        output.WriteMessage(ReadOnly);
      }
      if (modeCase_ == ModeOneofCase.ReadWrite) {
        output.WriteRawTag(26);
        output.WriteMessage(ReadWrite);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (modeCase_ == ModeOneofCase.ReadOnly) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ReadOnly);
      }
      if (modeCase_ == ModeOneofCase.ReadWrite) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ReadWrite);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TransactionOptions other) {
      if (other == null) {
        return;
      }
      switch (other.ModeCase) {
        case ModeOneofCase.ReadOnly:
          if (ReadOnly == null) {
            ReadOnly = new global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadOnly();
          }
          ReadOnly.MergeFrom(other.ReadOnly);
          break;
        case ModeOneofCase.ReadWrite:
          if (ReadWrite == null) {
            ReadWrite = new global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadWrite();
          }
          ReadWrite.MergeFrom(other.ReadWrite);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 18: {
            global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadOnly subBuilder = new global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadOnly();
            if (modeCase_ == ModeOneofCase.ReadOnly) {
              subBuilder.MergeFrom(ReadOnly);
            }
            input.ReadMessage(subBuilder);
            ReadOnly = subBuilder;
            break;
          }
          case 26: {
            global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadWrite subBuilder = new global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Types.ReadWrite();
            if (modeCase_ == ModeOneofCase.ReadWrite) {
              subBuilder.MergeFrom(ReadWrite);
            }
            input.ReadMessage(subBuilder);
            ReadWrite = subBuilder;
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the TransactionOptions message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      /// <summary>
      /// Options for a transaction that can be used to read and write documents.
      /// </summary>
      public sealed partial class ReadWrite : pb::IMessage<ReadWrite> {
        private static readonly pb::MessageParser<ReadWrite> _parser = new pb::MessageParser<ReadWrite>(() => new ReadWrite());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<ReadWrite> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ReadWrite() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ReadWrite(ReadWrite other) : this() {
          retryTransaction_ = other.retryTransaction_;
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ReadWrite Clone() {
          return new ReadWrite(this);
        }

        /// <summary>Field number for the "retry_transaction" field.</summary>
        public const int RetryTransactionFieldNumber = 1;
        private pb::ByteString retryTransaction_ = pb::ByteString.Empty;
        /// <summary>
        /// An optional transaction to retry.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public pb::ByteString RetryTransaction {
          get { return retryTransaction_; }
          set {
            retryTransaction_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as ReadWrite);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(ReadWrite other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (RetryTransaction != other.RetryTransaction) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (RetryTransaction.Length != 0) hash ^= RetryTransaction.GetHashCode();
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (RetryTransaction.Length != 0) {
            output.WriteRawTag(10);
            output.WriteBytes(RetryTransaction);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (RetryTransaction.Length != 0) {
            size += 1 + pb::CodedOutputStream.ComputeBytesSize(RetryTransaction);
          }
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(ReadWrite other) {
          if (other == null) {
            return;
          }
          if (other.RetryTransaction.Length != 0) {
            RetryTransaction = other.RetryTransaction;
          }
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 10: {
                RetryTransaction = input.ReadBytes();
                break;
              }
            }
          }
        }

      }

      /// <summary>
      /// Options for a transaction that can only be used to read documents.
      /// </summary>
      public sealed partial class ReadOnly : pb::IMessage<ReadOnly> {
        private static readonly pb::MessageParser<ReadOnly> _parser = new pb::MessageParser<ReadOnly>(() => new ReadOnly());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<ReadOnly> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Google.Cloud.Firestore.V1Beta1.TransactionOptions.Descriptor.NestedTypes[1]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ReadOnly() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ReadOnly(ReadOnly other) : this() {
          switch (other.ConsistencySelectorCase) {
            case ConsistencySelectorOneofCase.ReadTime:
              ReadTime = other.ReadTime.Clone();
              break;
          }

          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ReadOnly Clone() {
          return new ReadOnly(this);
        }

        /// <summary>Field number for the "read_time" field.</summary>
        public const int ReadTimeFieldNumber = 2;
        /// <summary>
        /// Reads documents at the given time.
        /// This may not be older than 60 seconds.
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public global::Google.Protobuf.WellKnownTypes.Timestamp ReadTime {
          get { return consistencySelectorCase_ == ConsistencySelectorOneofCase.ReadTime ? (global::Google.Protobuf.WellKnownTypes.Timestamp) consistencySelector_ : null; }
          set {
            consistencySelector_ = value;
            consistencySelectorCase_ = value == null ? ConsistencySelectorOneofCase.None : ConsistencySelectorOneofCase.ReadTime;
          }
        }

        private object consistencySelector_;
        /// <summary>Enum of possible cases for the "consistency_selector" oneof.</summary>
        public enum ConsistencySelectorOneofCase {
          None = 0,
          ReadTime = 2,
        }
        private ConsistencySelectorOneofCase consistencySelectorCase_ = ConsistencySelectorOneofCase.None;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public ConsistencySelectorOneofCase ConsistencySelectorCase {
          get { return consistencySelectorCase_; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void ClearConsistencySelector() {
          consistencySelectorCase_ = ConsistencySelectorOneofCase.None;
          consistencySelector_ = null;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as ReadOnly);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(ReadOnly other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (!object.Equals(ReadTime, other.ReadTime)) return false;
          if (ConsistencySelectorCase != other.ConsistencySelectorCase) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (consistencySelectorCase_ == ConsistencySelectorOneofCase.ReadTime) hash ^= ReadTime.GetHashCode();
          hash ^= (int) consistencySelectorCase_;
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (consistencySelectorCase_ == ConsistencySelectorOneofCase.ReadTime) {
            output.WriteRawTag(18);
            output.WriteMessage(ReadTime);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (consistencySelectorCase_ == ConsistencySelectorOneofCase.ReadTime) {
            size += 1 + pb::CodedOutputStream.ComputeMessageSize(ReadTime);
          }
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(ReadOnly other) {
          if (other == null) {
            return;
          }
          switch (other.ConsistencySelectorCase) {
            case ConsistencySelectorOneofCase.ReadTime:
              if (ReadTime == null) {
                ReadTime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
              }
              ReadTime.MergeFrom(other.ReadTime);
              break;
          }

          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 18: {
                global::Google.Protobuf.WellKnownTypes.Timestamp subBuilder = new global::Google.Protobuf.WellKnownTypes.Timestamp();
                if (consistencySelectorCase_ == ConsistencySelectorOneofCase.ReadTime) {
                  subBuilder.MergeFrom(ReadTime);
                }
                input.ReadMessage(subBuilder);
                ReadTime = subBuilder;
                break;
              }
            }
          }
        }

      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
