﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:2.0.50727.8662
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MsgPack.Serialization.GeneratedSerializers.MapBased {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MsgPack.Serialization.CodeDomSerializers.CodeDomSerializerBuilder", "0.6.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class MsgPack_Serialization_AddOnlyCollection_1_MsgPack_MessagePackObjectArray_Serializer : MsgPack.Serialization.CollectionSerializers.EnumerableMessagePackSerializer<MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]>, MsgPack.MessagePackObject[]> {
        
        public MsgPack_Serialization_AddOnlyCollection_1_MsgPack_MessagePackObjectArray_Serializer(MsgPack.Serialization.SerializationContext context) : 
                base(context, MsgPack_Serialization_AddOnlyCollection_1_MsgPack_MessagePackObjectArray_Serializer.RestoreSchema()) {
        }
        
        protected override void AddItem(MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]> collection, MsgPack.MessagePackObject[] item) {
            collection.Add(item);
        }
        
        protected internal override MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]> UnpackFromCore(MsgPack.Unpacker unpacker) {
            if ((unpacker.IsArrayHeader == false)) {
                throw MsgPack.Serialization.SerializationExceptions.NewIsNotArrayHeader();
            }
            int itemsCount = default(int);
            itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
            MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]> collection = default(MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]>);
            collection = new MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]>();
            this.UnpackToCore(unpacker, collection);
            return collection;
        }
        
        protected override MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]> CreateInstance(int initialCapacity) {
            MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]> collection = default(MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]>);
            collection = new MsgPack.Serialization.AddOnlyCollection<MsgPack.MessagePackObject[]>();
            return collection;
        }
        
        private static MsgPack.Serialization.PolymorphismSchema RestoreSchema() {
            MsgPack.Serialization.PolymorphismSchema schema = default(MsgPack.Serialization.PolymorphismSchema);
            schema = null;
            return schema;
        }
    }
}
