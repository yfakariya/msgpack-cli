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
    public class MsgPack_Serialization_AbstractClassListItemKnownTypeSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.AbstractClassListItemKnownType> {
        
        private MsgPack.Serialization.MessagePackSerializer<string> _serializer0;
        
        private MsgPack.Serialization.MessagePackSerializer<System.Collections.Generic.IList<MsgPack.Serialization.AbstractFileSystemEntry>> _serializer1;
        
        public MsgPack_Serialization_AbstractClassListItemKnownTypeSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            MsgPack.Serialization.PolymorphismSchema itemsSchema0 = default(MsgPack.Serialization.PolymorphismSchema);
            System.Collections.Generic.Dictionary<string, System.Type> itemsSchemaTypeMap0 = default(System.Collections.Generic.Dictionary<string, System.Type>);
            itemsSchemaTypeMap0 = new System.Collections.Generic.Dictionary<string, System.Type>(1);
            itemsSchemaTypeMap0.Add("1", typeof(MsgPack.Serialization.FileEntry));
            itemsSchema0 = MsgPack.Serialization.PolymorphismSchema.ForPolymorphicObject(typeof(MsgPack.Serialization.AbstractFileSystemEntry), itemsSchemaTypeMap0);
            schema0 = MsgPack.Serialization.PolymorphismSchema.ForContextSpecifiedCollection(typeof(System.Collections.Generic.IList<MsgPack.Serialization.AbstractFileSystemEntry>), itemsSchema0);
            this._serializer0 = context.GetSerializer<string>(schema0);
            MsgPack.Serialization.PolymorphismSchema schema1 = default(MsgPack.Serialization.PolymorphismSchema);
            MsgPack.Serialization.PolymorphismSchema itemsSchema1 = default(MsgPack.Serialization.PolymorphismSchema);
            System.Collections.Generic.Dictionary<string, System.Type> itemsSchema1TypeMap0 = default(System.Collections.Generic.Dictionary<string, System.Type>);
            itemsSchema1TypeMap0 = new System.Collections.Generic.Dictionary<string, System.Type>(1);
            itemsSchema1TypeMap0.Add("1", typeof(MsgPack.Serialization.FileEntry));
            itemsSchema1 = MsgPack.Serialization.PolymorphismSchema.ForPolymorphicObject(typeof(MsgPack.Serialization.AbstractFileSystemEntry), itemsSchema1TypeMap0);
            schema1 = MsgPack.Serialization.PolymorphismSchema.ForContextSpecifiedCollection(typeof(System.Collections.Generic.IList<MsgPack.Serialization.AbstractFileSystemEntry>), itemsSchema1);
            this._serializer1 = context.GetSerializer<System.Collections.Generic.IList<MsgPack.Serialization.AbstractFileSystemEntry>>(schema1);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.AbstractClassListItemKnownType objectTree) {
            packer.PackMapHeader(1);
            this._serializer0.PackTo(packer, "Value");
            this._serializer1.PackTo(packer, objectTree.Value);
        }
        
        protected internal override MsgPack.Serialization.AbstractClassListItemKnownType UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.AbstractClassListItemKnownType result = default(MsgPack.Serialization.AbstractClassListItemKnownType);
            result = new MsgPack.Serialization.AbstractClassListItemKnownType();
            if (unpacker.IsArrayHeader) {
                int unpacked = default(int);
                int itemsCount = default(int);
                itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                System.Collections.Generic.IList<MsgPack.Serialization.AbstractFileSystemEntry> nullable = default(System.Collections.Generic.IList<MsgPack.Serialization.AbstractFileSystemEntry>);
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
                    result.Value = nullable;
                }
                unpacked = (unpacked + 1);
            }
            else {
                int itemsCount0 = default(int);
                itemsCount0 = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                for (int i = 0; (i < itemsCount0); i = (i + 1)) {
                    string key = default(string);
                    string nullable0 = default(string);
                    nullable0 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.AbstractClassListItemKnownType), "MemberName");
                    if (((nullable0 == null) 
                                == false)) {
                        key = nullable0;
                    }
                    else {
                        throw MsgPack.Serialization.SerializationExceptions.NewNullIsProhibited("MemberName");
                    }
                    if ((key == "Value")) {
                        System.Collections.Generic.IList<MsgPack.Serialization.AbstractFileSystemEntry> nullable1 = default(System.Collections.Generic.IList<MsgPack.Serialization.AbstractFileSystemEntry>);
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
                            result.Value = nullable1;
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
