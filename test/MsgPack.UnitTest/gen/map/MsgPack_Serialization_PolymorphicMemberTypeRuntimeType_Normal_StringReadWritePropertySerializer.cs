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
    public class MsgPack_Serialization_PolymorphicMemberTypeRuntimeType_Normal_StringReadWritePropertySerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.PolymorphicMemberTypeRuntimeType_Normal_StringReadWriteProperty> {
        
        private MsgPack.Serialization.MessagePackSerializer<string> _serializer0;
        
        public MsgPack_Serialization_PolymorphicMemberTypeRuntimeType_Normal_StringReadWritePropertySerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            schema0 = null;
            this._serializer0 = context.GetSerializer<string>(schema0);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.PolymorphicMemberTypeRuntimeType_Normal_StringReadWriteProperty objectTree) {
            packer.PackMapHeader(1);
            this._serializer0.PackTo(packer, "String");
            this._serializer0.PackTo(packer, objectTree.String);
        }
        
        protected internal override MsgPack.Serialization.PolymorphicMemberTypeRuntimeType_Normal_StringReadWriteProperty UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.PolymorphicMemberTypeRuntimeType_Normal_StringReadWriteProperty result = default(MsgPack.Serialization.PolymorphicMemberTypeRuntimeType_Normal_StringReadWriteProperty);
            result = new MsgPack.Serialization.PolymorphicMemberTypeRuntimeType_Normal_StringReadWriteProperty();
            if (unpacker.IsArrayHeader) {
                int unpacked = default(int);
                int itemsCount = default(int);
                itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                string nullable = default(string);
                if ((unpacked < itemsCount)) {
                    nullable = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.PolymorphicMemberTypeRuntimeType_Normal_StringReadWriteProperty), "System.String String");
                }
                if (((nullable == null) 
                            == false)) {
                    result.String = nullable;
                }
                unpacked = (unpacked + 1);
            }
            else {
                int itemsCount0 = default(int);
                itemsCount0 = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                for (int i = 0; (i < itemsCount0); i = (i + 1)) {
                    string key = default(string);
                    string nullable0 = default(string);
                    nullable0 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.PolymorphicMemberTypeRuntimeType_Normal_StringReadWriteProperty), "MemberName");
                    if (((nullable0 == null) 
                                == false)) {
                        key = nullable0;
                    }
                    else {
                        throw MsgPack.Serialization.SerializationExceptions.NewNullIsProhibited("MemberName");
                    }
                    if ((key == "String")) {
                        string nullable1 = default(string);
                        nullable1 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.PolymorphicMemberTypeRuntimeType_Normal_StringReadWriteProperty), "System.String String");
                        if (((nullable1 == null) 
                                    == false)) {
                            result.String = nullable1;
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
