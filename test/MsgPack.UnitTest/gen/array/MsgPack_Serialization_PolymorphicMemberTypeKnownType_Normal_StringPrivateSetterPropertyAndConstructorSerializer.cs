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
    public class MsgPack_Serialization_PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructorSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor> {
        
        private MsgPack.Serialization.MessagePackSerializer<string> _serializer0;
        
        private System.Reflection.MethodBase _methodBasePolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor_set_String0;
        
        public MsgPack_Serialization_PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructorSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            schema0 = null;
            this._serializer0 = context.GetSerializer<string>(schema0);
            this._methodBasePolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor_set_String0 = typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor).GetMethod("set_String", (System.Reflection.BindingFlags.Instance 
                            | (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)), null, new System.Type[] {
                        typeof(string)}, null);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor objectTree) {
            packer.PackArrayHeader(1);
            this._serializer0.PackTo(packer, objectTree.String);
        }
        
        protected internal override MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor result = default(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor);
            result = new MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor();
            if (unpacker.IsArrayHeader) {
                int unpacked = default(int);
                int itemsCount = default(int);
                itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                string nullable = default(string);
                if ((unpacked < itemsCount)) {
                    nullable = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor), "System.String String");
                }
                if (((nullable == null) 
                            == false)) {
                    this._methodBasePolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor_set_String0.Invoke(result, new object[] {
                                nullable});
                }
                unpacked = (unpacked + 1);
            }
            else {
                int itemsCount0 = default(int);
                itemsCount0 = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                for (int i = 0; (i < itemsCount0); i = (i + 1)) {
                    string key = default(string);
                    string nullable0 = default(string);
                    nullable0 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor), "MemberName");
                    if (((nullable0 == null) 
                                == false)) {
                        key = nullable0;
                    }
                    else {
                        throw MsgPack.Serialization.SerializationExceptions.NewNullIsProhibited("MemberName");
                    }
                    if ((key == "String")) {
                        string nullable1 = default(string);
                        nullable1 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor), "System.String String");
                        if (((nullable1 == null) 
                                    == false)) {
                            this._methodBasePolymorphicMemberTypeKnownType_Normal_StringPrivateSetterPropertyAndConstructor_set_String0.Invoke(result, new object[] {
                                        nullable1});
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
