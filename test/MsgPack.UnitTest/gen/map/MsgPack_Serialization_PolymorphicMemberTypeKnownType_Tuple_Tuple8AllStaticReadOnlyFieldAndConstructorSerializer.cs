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
    public class MsgPack_Serialization_PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructorSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructor> {
        
        private MsgPack.Serialization.MessagePackSerializer<string> _serializer0;
        
        private MsgPack.Serialization.MessagePackSerializer<System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>>> _serializer1;
        
        public MsgPack_Serialization_PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructorSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            MsgPack.Serialization.PolymorphismSchema[] tupleItemsSchema0 = default(MsgPack.Serialization.PolymorphismSchema[]);
            tupleItemsSchema0 = new MsgPack.Serialization.PolymorphismSchema[8];
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema0 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema0 = null;
            tupleItemsSchema0[0] = tupleItemSchema0;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema1 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema1 = null;
            tupleItemsSchema0[1] = tupleItemSchema1;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema2 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema2 = null;
            tupleItemsSchema0[2] = tupleItemSchema2;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema3 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema3 = null;
            tupleItemsSchema0[3] = tupleItemSchema3;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema4 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema4 = null;
            tupleItemsSchema0[4] = tupleItemSchema4;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema5 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema5 = null;
            tupleItemsSchema0[5] = tupleItemSchema5;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema6 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema6 = null;
            tupleItemsSchema0[6] = tupleItemSchema6;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema7 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema7 = null;
            tupleItemsSchema0[7] = tupleItemSchema7;
            schema0 = MsgPack.Serialization.PolymorphismSchema.ForPolymorphicTuple(typeof(System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>>), tupleItemsSchema0);
            this._serializer0 = context.GetSerializer<string>(schema0);
            MsgPack.Serialization.PolymorphismSchema schema1 = default(MsgPack.Serialization.PolymorphismSchema);
            MsgPack.Serialization.PolymorphismSchema[] tupleItemsSchema1 = default(MsgPack.Serialization.PolymorphismSchema[]);
            tupleItemsSchema1 = new MsgPack.Serialization.PolymorphismSchema[8];
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema8 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema8 = null;
            tupleItemsSchema1[0] = tupleItemSchema8;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema9 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema9 = null;
            tupleItemsSchema1[1] = tupleItemSchema9;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema10 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema10 = null;
            tupleItemsSchema1[2] = tupleItemSchema10;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema11 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema11 = null;
            tupleItemsSchema1[3] = tupleItemSchema11;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema12 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema12 = null;
            tupleItemsSchema1[4] = tupleItemSchema12;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema13 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema13 = null;
            tupleItemsSchema1[5] = tupleItemSchema13;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema14 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema14 = null;
            tupleItemsSchema1[6] = tupleItemSchema14;
            MsgPack.Serialization.PolymorphismSchema tupleItemSchema15 = default(MsgPack.Serialization.PolymorphismSchema);
            tupleItemSchema15 = null;
            tupleItemsSchema1[7] = tupleItemSchema15;
            schema1 = MsgPack.Serialization.PolymorphismSchema.ForPolymorphicTuple(typeof(System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>>), tupleItemsSchema1);
            this._serializer1 = context.GetSerializer<System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>>>(schema1);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructor objectTree) {
            packer.PackMapHeader(1);
            this._serializer0.PackTo(packer, "Tuple8AllStatic");
            this._serializer1.PackTo(packer, objectTree.Tuple8AllStatic);
        }
        
        protected internal override MsgPack.Serialization.PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructor UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructor result = default(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructor);
            if (unpacker.IsArrayHeader) {
                int unpacked = default(int);
                int itemsCount = default(int);
                itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>> ctorArg0 = default(System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>>);
                ctorArg0 = null;
                System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>> nullable = default(System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>>);
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
                    ctorArg0 = nullable;
                }
                unpacked = (unpacked + 1);
                result = new MsgPack.Serialization.PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructor(ctorArg0);
            }
            else {
                int itemsCount0 = default(int);
                itemsCount0 = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>> ctorArg00 = default(System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>>);
                ctorArg00 = null;
                for (int i = 0; (i < itemsCount0); i = (i + 1)) {
                    string key = default(string);
                    string nullable0 = default(string);
                    nullable0 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructor), "MemberName");
                    if (((nullable0 == null) 
                                == false)) {
                        key = nullable0;
                    }
                    else {
                        throw MsgPack.Serialization.SerializationExceptions.NewNullIsProhibited("MemberName");
                    }
                    if ((key == "Tuple8AllStatic")) {
                        System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>> nullable1 = default(System.Tuple<string, string, string, string, string, string, string, System.Tuple<string>>);
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
                            ctorArg00 = nullable1;
                        }
                    }
                    else {
                        unpacker.Skip();
                    }
                }
                result = new MsgPack.Serialization.PolymorphicMemberTypeKnownType_Tuple_Tuple8AllStaticReadOnlyFieldAndConstructor(ctorArg00);
            }
            return result;
        }
    }
}
