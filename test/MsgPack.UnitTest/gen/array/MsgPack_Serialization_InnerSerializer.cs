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
    public class MsgPack_Serialization_InnerSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.Inner> {
        
        private MsgPack.Serialization.MessagePackSerializer<string> _serializer0;
        
        private MsgPack.Serialization.MessagePackSerializer<byte[]> _serializer1;
        
        public MsgPack_Serialization_InnerSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            schema0 = null;
            this._serializer0 = context.GetSerializer<string>(schema0);
            MsgPack.Serialization.PolymorphismSchema schema1 = default(MsgPack.Serialization.PolymorphismSchema);
            schema1 = null;
            this._serializer1 = context.GetSerializer<byte[]>(schema1);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.Inner objectTree) {
            packer.PackArrayHeader(3);
            this._serializer0.PackTo(packer, objectTree.A);
            this._serializer1.PackTo(packer, objectTree.Bytes);
            this._serializer0.PackTo(packer, objectTree.C);
        }
        
        protected internal override MsgPack.Serialization.Inner UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.Inner result = default(MsgPack.Serialization.Inner);
            result = new MsgPack.Serialization.Inner();
            if (unpacker.IsArrayHeader) {
                int unpacked = default(int);
                int itemsCount = default(int);
                itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                string nullable = default(string);
                if ((unpacked < itemsCount)) {
                    nullable = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.Inner), "System.String A");
                }
                if (((nullable == null) 
                            == false)) {
                    result.A = nullable;
                }
                unpacked = (unpacked + 1);
                byte[] nullable0 = default(byte[]);
                if ((unpacked < itemsCount)) {
                    nullable0 = MsgPack.Serialization.UnpackHelpers.UnpackBinaryValue(unpacker, typeof(MsgPack.Serialization.Inner), "Byte[] Bytes");
                }
                if (((nullable0 == null) 
                            == false)) {
                    result.Bytes = nullable0;
                }
                unpacked = (unpacked + 1);
                string nullable1 = default(string);
                if ((unpacked < itemsCount)) {
                    nullable1 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.Inner), "System.String C");
                }
                if (((nullable1 == null) 
                            == false)) {
                    result.C = nullable1;
                }
                unpacked = (unpacked + 1);
            }
            else {
                int itemsCount0 = default(int);
                itemsCount0 = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                for (int i = 0; (i < itemsCount0); i = (i + 1)) {
                    string key = default(string);
                    string nullable2 = default(string);
                    nullable2 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.Inner), "MemberName");
                    if (((nullable2 == null) 
                                == false)) {
                        key = nullable2;
                    }
                    else {
                        throw MsgPack.Serialization.SerializationExceptions.NewNullIsProhibited("MemberName");
                    }
                    if ((key == "C")) {
                        string nullable5 = default(string);
                        nullable5 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.Inner), "System.String C");
                        if (((nullable5 == null) 
                                    == false)) {
                            result.C = nullable5;
                        }
                    }
                    else {
                        if ((key == "Bytes")) {
                            byte[] nullable4 = default(byte[]);
                            nullable4 = MsgPack.Serialization.UnpackHelpers.UnpackBinaryValue(unpacker, typeof(MsgPack.Serialization.Inner), "Byte[] Bytes");
                            if (((nullable4 == null) 
                                        == false)) {
                                result.Bytes = nullable4;
                            }
                        }
                        else {
                            if ((key == "A")) {
                                string nullable3 = default(string);
                                nullable3 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.Inner), "System.String A");
                                if (((nullable3 == null) 
                                            == false)) {
                                    result.A = nullable3;
                                }
                            }
                            else {
                                unpacker.Skip();
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
