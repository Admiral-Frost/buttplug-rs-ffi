// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace ButtplugFFI
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct RSSILevelReading : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static RSSILevelReading GetRootAsRSSILevelReading(ByteBuffer _bb) { return GetRootAsRSSILevelReading(_bb, new RSSILevelReading()); }
  public static RSSILevelReading GetRootAsRSSILevelReading(ByteBuffer _bb, RSSILevelReading obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public RSSILevelReading __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }


  public static void StartRSSILevelReading(FlatBufferBuilder builder) { builder.StartTable(0); }
  public static Offset<ButtplugFFI.RSSILevelReading> EndRSSILevelReading(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<ButtplugFFI.RSSILevelReading>(o);
  }
};


}
