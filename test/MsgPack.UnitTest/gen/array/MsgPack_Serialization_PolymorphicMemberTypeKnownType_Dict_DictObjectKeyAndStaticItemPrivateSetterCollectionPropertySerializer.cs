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
    public class MsgPack_Serialization_PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionPropertySerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty> {
        
        private MsgPack.Serialization.MessagePackSerializer<System.Collections.Generic.IDictionary<object, string>> _serializer0;
        
        private System.Reflection.MethodBase _methodBasePolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty_set_DictObjectKeyAndStaticItem0;
        
        public MsgPack_Serialization_PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionPropertySerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            MsgPack.Serialization.PolymorphismSchema keysSchema0 = default(MsgPack.Serialization.PolymorphismSchema);
            System.Collections.Generic.Dictionary<string, System.Type> keysSchemaTypeMap0 = default(System.Collections.Generic.Dictionary<string, System.Type>);
            keysSchemaTypeMap0 = new System.Collections.Generic.Dictionary<string, System.Type>(2);
            keysSchemaTypeMap0.Add("0", typeof(MsgPack.Serialization.FileEntry));
            keysSchemaTypeMap0.Add("1", typeof(MsgPack.Serialization.DirectoryEntry));
            keysSchema0 = MsgPack.Serialization.PolymorphismSchema.ForPolymorphicObject(typeof(object), keysSchemaTypeMap0);
            schema0 = MsgPack.Serialization.PolymorphismSchema.ForContextSpecifiedDictionary(typeof(System.Collections.Generic.IDictionary<object, string>), keysSchema0, null);
            this._serializer0 = context.GetSerializer<System.Collections.Generic.IDictionary<object, string>>(schema0);
            this._methodBasePolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty_set_DictObjectKeyAndStaticItem0 = typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty).GetMethod("set_DictObjectKeyAndStaticItem", (System.Reflection.BindingFlags.Instance 
                            | (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)), null, new System.Type[] {
                        typeof(System.Collections.Generic.IDictionary<object, string>)}, null);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty objectTree) {
            packer.PackArrayHeader(1);
            this._serializer0.PackTo(packer, objectTree.DictObjectKeyAndStaticItem);
        }
        
        protected internal override MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty result = default(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty);
            result = new MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty();
            if (unpacker.IsArrayHeader) {
                int unpacked = default(int);
                int itemsCount = default(int);
                itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                System.Collections.Generic.IDictionary<object, string> nullable = default(System.Collections.Generic.IDictionary<object, string>);
                if ((unpacked < itemsCount)) {
                    if ((unpacker.Read() == false)) {
                        throw MsgPack.Serialization.SerializationExceptions.NewMissingItem(0);
                    }
                    if (((unpacker.IsArrayHeader == false) 
                                && (unpacker.IsMapHeader == false))) {
                        nullable = this._serializer0.UnpackFrom(unpacker);
                    }
                    else {
                        MsgPack.Unpacker disposable = default(MsgPack.Unpacker);
                        disposable = unpacker.ReadSubtree();
                        try {
                            nullable = this._serializer0.UnpackFrom(disposable);
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
                    if ((result.DictObjectKeyAndStaticItem == null)) {
                        this._methodBasePolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty_set_DictObjectKeyAndStaticItem0.Invoke(result, new object[] {
                                    nullable});
                    }
                    else {
                        System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object, string>> enumerator = nullable.GetEnumerator();
                        System.Collections.Generic.KeyValuePair<object, string> current;
                        try {
                            for (
                            ; enumerator.MoveNext(); 
                            ) {
                                current = enumerator.Current;
                                result.DictObjectKeyAndStaticItem.Add(current.Key, current.Value);
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
                    nullable0 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty), "MemberName");
                    if (((nullable0 == null) 
                                == false)) {
                        key = nullable0;
                    }
                    else {
                        throw MsgPack.Serialization.SerializationExceptions.NewNullIsProhibited("MemberName");
                    }
                    if ((key == "DictObjectKeyAndStaticItem")) {
                        System.Collections.Generic.IDictionary<object, string> nullable1 = default(System.Collections.Generic.IDictionary<object, string>);
                        if ((unpacker.Read() == false)) {
                            throw MsgPack.Serialization.SerializationExceptions.NewMissingItem(i);
                        }
                        if (((unpacker.IsArrayHeader == false) 
                                    && (unpacker.IsMapHeader == false))) {
                            nullable1 = this._serializer0.UnpackFrom(unpacker);
                        }
                        else {
                            MsgPack.Unpacker disposable0 = default(MsgPack.Unpacker);
                            disposable0 = unpacker.ReadSubtree();
                            try {
                                nullable1 = this._serializer0.UnpackFrom(disposable0);
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
                            if ((result.DictObjectKeyAndStaticItem == null)) {
                                this._methodBasePolymorphicMemberTypeKnownType_Dict_DictObjectKeyAndStaticItemPrivateSetterCollectionProperty_set_DictObjectKeyAndStaticItem0.Invoke(result, new object[] {
                                            nullable1});
                            }
                            else {
                                System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object, string>> enumerator0 = nullable1.GetEnumerator();
                                System.Collections.Generic.KeyValuePair<object, string> current0;
                                try {
                                    for (
                                    ; enumerator0.MoveNext(); 
                                    ) {
                                        current0 = enumerator0.Current;
                                        result.DictObjectKeyAndStaticItem.Add(current0.Key, current0.Value);
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
