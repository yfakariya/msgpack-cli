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
    public class MsgPack_Serialization_PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionPropertySerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty> {
        
        private MsgPack.Serialization.MessagePackSerializer<string> _serializer0;
        
        private MsgPack.Serialization.MessagePackSerializer<System.Collections.Generic.IDictionary<MsgPack.Serialization.FileSystemEntry, string>> _serializer1;
        
        private System.Reflection.MethodBase _methodBasePolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty_set_DictPolymorphicKeyAndStaticItem0;
        
        public MsgPack_Serialization_PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionPropertySerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            MsgPack.Serialization.PolymorphismSchema keysSchema0 = default(MsgPack.Serialization.PolymorphismSchema);
            System.Collections.Generic.Dictionary<string, System.Type> keysSchemaTypeMap0 = default(System.Collections.Generic.Dictionary<string, System.Type>);
            keysSchemaTypeMap0 = new System.Collections.Generic.Dictionary<string, System.Type>(2);
            keysSchemaTypeMap0.Add("1", typeof(MsgPack.Serialization.DirectoryEntry));
            keysSchemaTypeMap0.Add("0", typeof(MsgPack.Serialization.FileEntry));
            keysSchema0 = MsgPack.Serialization.PolymorphismSchema.ForPolymorphicObject(typeof(MsgPack.Serialization.FileSystemEntry), keysSchemaTypeMap0);
            schema0 = MsgPack.Serialization.PolymorphismSchema.ForContextSpecifiedDictionary(typeof(System.Collections.Generic.IDictionary<MsgPack.Serialization.FileSystemEntry, string>), keysSchema0, null);
            this._serializer0 = context.GetSerializer<string>(schema0);
            MsgPack.Serialization.PolymorphismSchema schema1 = default(MsgPack.Serialization.PolymorphismSchema);
            MsgPack.Serialization.PolymorphismSchema keysSchema1 = default(MsgPack.Serialization.PolymorphismSchema);
            System.Collections.Generic.Dictionary<string, System.Type> keysSchema1TypeMap0 = default(System.Collections.Generic.Dictionary<string, System.Type>);
            keysSchema1TypeMap0 = new System.Collections.Generic.Dictionary<string, System.Type>(2);
            keysSchema1TypeMap0.Add("1", typeof(MsgPack.Serialization.DirectoryEntry));
            keysSchema1TypeMap0.Add("0", typeof(MsgPack.Serialization.FileEntry));
            keysSchema1 = MsgPack.Serialization.PolymorphismSchema.ForPolymorphicObject(typeof(MsgPack.Serialization.FileSystemEntry), keysSchema1TypeMap0);
            schema1 = MsgPack.Serialization.PolymorphismSchema.ForContextSpecifiedDictionary(typeof(System.Collections.Generic.IDictionary<MsgPack.Serialization.FileSystemEntry, string>), keysSchema1, null);
            this._serializer1 = context.GetSerializer<System.Collections.Generic.IDictionary<MsgPack.Serialization.FileSystemEntry, string>>(schema1);
            this._methodBasePolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty_set_DictPolymorphicKeyAndStaticItem0 = typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty).GetMethod("set_DictPolymorphicKeyAndStaticItem", (System.Reflection.BindingFlags.Instance 
                            | (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)), null, new System.Type[] {
                        typeof(System.Collections.Generic.IDictionary<MsgPack.Serialization.FileSystemEntry, string>)}, null);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty objectTree) {
            packer.PackMapHeader(1);
            this._serializer0.PackTo(packer, "DictPolymorphicKeyAndStaticItem");
            this._serializer1.PackTo(packer, objectTree.DictPolymorphicKeyAndStaticItem);
        }
        
        protected internal override MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty result = default(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty);
            result = new MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty();
            if (unpacker.IsArrayHeader) {
                int unpacked = default(int);
                int itemsCount = default(int);
                itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                System.Collections.Generic.IDictionary<MsgPack.Serialization.FileSystemEntry, string> nullable = default(System.Collections.Generic.IDictionary<MsgPack.Serialization.FileSystemEntry, string>);
                if ((unpacked < itemsCount)) {
                    if ((unpacker.Read() == false)) {
                        throw MsgPack.Serialization.SerializationExceptions.NewMissingItem(0);
                    }
                    if (((unpacker.IsArrayHeader == false) 
                                && (unpacker.IsMapHeader == false))) {
                        nullable = this._serializer1.UnpackFrom(unpacker);
                    }
                    else {
                        MsgPack.Unpacker disposable = default(MsgPack.Unpacker);
                        disposable = unpacker.ReadSubtree();
                        try {
                            nullable = this._serializer1.UnpackFrom(disposable);
                        }
                        finally {
                            if (((disposable == null) 
                                        == false)) {
                                disposable.Dispose();
                            }
                        }
                    }
                }
                if (((nullable == null) 
                            == false)) {
                    if ((result.DictPolymorphicKeyAndStaticItem == null)) {
                        this._methodBasePolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty_set_DictPolymorphicKeyAndStaticItem0.Invoke(result, new object[] {
                                    nullable});
                    }
                    else {
                        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<MsgPack.Serialization.FileSystemEntry, string>> enumerator = nullable.GetEnumerator();
                        System.Collections.Generic.KeyValuePair<MsgPack.Serialization.FileSystemEntry, string> current;
                        try {
                            for (
                            ; enumerator.MoveNext(); 
                            ) {
                                current = enumerator.Current;
                                result.DictPolymorphicKeyAndStaticItem.Add(current.Key, current.Value);
                            }
                        }
                        finally {
                            enumerator.Dispose();
                        }
                    }
                }
                unpacked = (unpacked + 1);
            }
            else {
                int itemsCount0 = default(int);
                itemsCount0 = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                for (int i = 0; (i < itemsCount0); i = (i + 1)) {
                    string key = default(string);
                    string nullable0 = default(string);
                    nullable0 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty), "MemberName");
                    if (((nullable0 == null) 
                                == false)) {
                        key = nullable0;
                    }
                    else {
                        throw MsgPack.Serialization.SerializationExceptions.NewNullIsProhibited("MemberName");
                    }
                    if ((key == "DictPolymorphicKeyAndStaticItem")) {
                        System.Collections.Generic.IDictionary<MsgPack.Serialization.FileSystemEntry, string> nullable1 = default(System.Collections.Generic.IDictionary<MsgPack.Serialization.FileSystemEntry, string>);
                        if ((unpacker.Read() == false)) {
                            throw MsgPack.Serialization.SerializationExceptions.NewMissingItem(i);
                        }
                        if (((unpacker.IsArrayHeader == false) 
                                    && (unpacker.IsMapHeader == false))) {
                            nullable1 = this._serializer1.UnpackFrom(unpacker);
                        }
                        else {
                            MsgPack.Unpacker disposable0 = default(MsgPack.Unpacker);
                            disposable0 = unpacker.ReadSubtree();
                            try {
                                nullable1 = this._serializer1.UnpackFrom(disposable0);
                            }
                            finally {
                                if (((disposable0 == null) 
                                            == false)) {
                                    disposable0.Dispose();
                                }
                            }
                        }
                        if (((nullable1 == null) 
                                    == false)) {
                            if ((result.DictPolymorphicKeyAndStaticItem == null)) {
                                this._methodBasePolymorphicMemberTypeKnownType_Dict_DictPolymorphicKeyAndStaticItemPrivateSetterCollectionProperty_set_DictPolymorphicKeyAndStaticItem0.Invoke(result, new object[] {
                                            nullable1});
                            }
                            else {
                                System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<MsgPack.Serialization.FileSystemEntry, string>> enumerator0 = nullable1.GetEnumerator();
                                System.Collections.Generic.KeyValuePair<MsgPack.Serialization.FileSystemEntry, string> current0;
                                try {
                                    for (
                                    ; enumerator0.MoveNext(); 
                                    ) {
                                        current0 = enumerator0.Current;
                                        result.DictPolymorphicKeyAndStaticItem.Add(current0.Key, current0.Value);
                                    }
                                }
                                finally {
                                    enumerator0.Dispose();
                                }
                            }
                        }
                    }
                    else {
                        unpacker.Skip();
                    }
                }
            }
            return result;
        }
    }
}
