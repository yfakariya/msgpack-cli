﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MsgPack.Serialization.GeneratedSerializers.ArrayBased {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MsgPack.Serialization.CodeDomSerializers.CodeDomSerializerBuilder", "0.6.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class MsgPack_Serialization_AddOnlyCollection_1_System_Int32Array_Serializer : MsgPack.Serialization.CollectionSerializers.EnumerableMessagePackSerializer<MsgPack.Serialization.AddOnlyCollection<int[]>, int[]> {
        
        public MsgPack_Serialization_AddOnlyCollection_1_System_Int32Array_Serializer(MsgPack.Serialization.SerializationContext context) : 
                base(context, MsgPack_Serialization_AddOnlyCollection_1_System_Int32Array_Serializer.RestoreSchema()) {
        }
        
        protected override void AddItem(MsgPack.Serialization.AddOnlyCollection<int[]> collection, int[] item) {
            collection.Add(item);
        }
        
        protected internal override MsgPack.Serialization.AddOnlyCollection<int[]> UnpackFromCore(MsgPack.Unpacker unpacker) {
            if ((unpacker.IsArrayHeader == false)) {
                throw MsgPack.Serialization.SerializationExceptions.NewIsNotArrayHeader();
            }
            int itemsCount = default(int);
            itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
            MsgPack.Serialization.AddOnlyCollection<int[]> collection = default(MsgPack.Serialization.AddOnlyCollection<int[]>);
            collection = new MsgPack.Serialization.AddOnlyCollection<int[]>();
            this.UnpackToCore(unpacker, collection);
            return collection;
        }
        
        protected override MsgPack.Serialization.AddOnlyCollection<int[]> CreateInstance(int initialCapacity) {
            MsgPack.Serialization.AddOnlyCollection<int[]> collection = default(MsgPack.Serialization.AddOnlyCollection<int[]>);
            collection = new MsgPack.Serialization.AddOnlyCollection<int[]>();
            return collection;
        }
        
        private static MsgPack.Serialization.PolymorphismSchema RestoreSchema() {
            MsgPack.Serialization.PolymorphismSchema schema = default(MsgPack.Serialization.PolymorphismSchema);
            schema = null;
            return schema;
        }
    }
}
