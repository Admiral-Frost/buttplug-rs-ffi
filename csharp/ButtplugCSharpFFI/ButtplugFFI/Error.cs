// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace ButtplugFFI
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct Error : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Error GetRootAsError(ByteBuffer _bb) { return GetRootAsError(_bb, new Error()); }
  public static Error GetRootAsError(ByteBuffer _bb, Error obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Error __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public ButtplugFFI.ButtplugErrorType ErrorType { get { int o = __p.__offset(4); return o != 0 ? (ButtplugFFI.ButtplugErrorType)__p.bb.GetSbyte(o + __p.bb_pos) : ButtplugFFI.ButtplugErrorType.ButtplugConnectorError; } }
  public string Message { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetMessageBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetMessageBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetMessageArray() { return __p.__vector_as_array<byte>(6); }
  public string Backtrace { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetBacktraceBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetBacktraceBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetBacktraceArray() { return __p.__vector_as_array<byte>(8); }

  public static Offset<ButtplugFFI.Error> CreateError(FlatBufferBuilder builder,
      ButtplugFFI.ButtplugErrorType error_type = ButtplugFFI.ButtplugErrorType.ButtplugConnectorError,
      StringOffset messageOffset = default(StringOffset),
      StringOffset backtraceOffset = default(StringOffset)) {
    builder.StartTable(3);
    Error.AddBacktrace(builder, backtraceOffset);
    Error.AddMessage(builder, messageOffset);
    Error.AddErrorType(builder, error_type);
    return Error.EndError(builder);
  }

  public static void StartError(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddErrorType(FlatBufferBuilder builder, ButtplugFFI.ButtplugErrorType errorType) { builder.AddSbyte(0, (sbyte)errorType, 0); }
  public static void AddMessage(FlatBufferBuilder builder, StringOffset messageOffset) { builder.AddOffset(1, messageOffset.Value, 0); }
  public static void AddBacktrace(FlatBufferBuilder builder, StringOffset backtraceOffset) { builder.AddOffset(2, backtraceOffset.Value, 0); }
  public static Offset<ButtplugFFI.Error> EndError(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<ButtplugFFI.Error>(o);
  }
};


}
