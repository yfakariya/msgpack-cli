﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MsgPack.Serialization.GeneratedSerializers.MapBased {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MsgPack.Serialization.CodeDomSerializers.CodeDomSerializerBuilder", "0.6.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class MsgPack_Serialization_ListValueType_1_System_Int32_Serializer : MsgPack.Serialization.CollectionSerializers.CollectionMessagePackSerializer<MsgPack.Serialization.ListValueType<int>, int> {
        
        public MsgPack_Serialization_ListValueType_1_System_Int32_Serializer(MsgPack.Serialization.SerializationContext context) : 
                base(context, MsgPack_Serialization_ListValueType_1_System_Int32_Serializer.RestoreSchema()) {
        }
        
        protected override MsgPack.Serialization.ListValueType<int> CreateInstance(int initialCapacity) {
            MsgPack.Serialization.ListValueType<int> collection = default(MsgPack.Serialization.ListValueType<int>);
            collection = new MsgPack.Serialization.ListValueType<int>(initialCapacity);
            return collection;
        }
        
        private static MsgPack.Serialization.PolymorphismSchema RestoreSchema() {
            MsgPack.Serialization.PolymorphismSchema schema = default(MsgPack.Serialization.PolymorphismSchema);
            schema = null;
            return schema;
        }
    }
}
