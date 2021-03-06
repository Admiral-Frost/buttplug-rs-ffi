// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace ButtplugFFI
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct DeviceMessage : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static DeviceMessage GetRootAsDeviceMessage(ByteBuffer _bb) { return GetRootAsDeviceMessage(_bb, new DeviceMessage()); }
  public static DeviceMessage GetRootAsDeviceMessage(ByteBuffer _bb, DeviceMessage obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public DeviceMessage __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Id { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint DeviceIndex { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public ButtplugFFI.DeviceMessageType MessageType { get { int o = __p.__offset(8); return o != 0 ? (ButtplugFFI.DeviceMessageType)__p.bb.Get(o + __p.bb_pos) : ButtplugFFI.DeviceMessageType.NONE; } }
  public TTable? Message<TTable>() where TTable : struct, IFlatbufferObject { int o = __p.__offset(10); return o != 0 ? (TTable?)__p.__union<TTable>(o + __p.bb_pos) : null; }

  public static Offset<ButtplugFFI.DeviceMessage> CreateDeviceMessage(FlatBufferBuilder builder,
      uint id = 0,
      uint device_index = 0,
      ButtplugFFI.DeviceMessageType message_type = ButtplugFFI.DeviceMessageType.NONE,
      int messageOffset = 0) {
    builder.StartTable(4);
    DeviceMessage.AddMessage(builder, messageOffset);
    DeviceMessage.AddDeviceIndex(builder, device_index);
    DeviceMessage.AddId(builder, id);
    DeviceMessage.AddMessageType(builder, message_type);
    return DeviceMessage.EndDeviceMessage(builder);
  }

  public static void StartDeviceMessage(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddId(FlatBufferBuilder builder, uint id) { builder.AddUint(0, id, 0); }
  public static void AddDeviceIndex(FlatBufferBuilder builder, uint deviceIndex) { builder.AddUint(1, deviceIndex, 0); }
  public static void AddMessageType(FlatBufferBuilder builder, ButtplugFFI.DeviceMessageType messageType) { builder.AddByte(2, (byte)messageType, 0); }
  public static void AddMessage(FlatBufferBuilder builder, int messageOffset) { builder.AddOffset(3, messageOffset, 0); }
  public static Offset<ButtplugFFI.DeviceMessage> EndDeviceMessage(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<ButtplugFFI.DeviceMessage>(o);
  }
  public static void FinishDeviceMessageBuffer(FlatBufferBuilder builder, Offset<ButtplugFFI.DeviceMessage> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedDeviceMessageBuffer(FlatBufferBuilder builder, Offset<ButtplugFFI.DeviceMessage> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
