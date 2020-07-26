﻿using System;
using System.IO;
using UAssetAPI.PropertyTypes;

namespace UAssetAPI.StructTypes
{
    public class QuatPropertyData : PropertyData<float[]>
    {
        public QuatPropertyData(string name, AssetReader asset, bool forceReadNull = false) : base(name, asset, forceReadNull)
        {
            Type = "Quat";
        }

        public QuatPropertyData()
        {
            Type = "Quat";
        }

        public override void Read(BinaryReader reader, long leng)
        {
            if (ForceReadNull) reader.ReadByte(); // null byte
            Value = new float[4];
            for (int i = 0; i < 4; i++)
            {
                Value[i] = reader.ReadSingle();
            }
        }

        public override int Write(BinaryWriter writer)
        {
            if (ForceReadNull) writer.Write((byte)0);
            for (int i = 0; i < 4; i++)
            {
                writer.Write(Value[i]);
            }
            return 0;
        }

        public override void FromString(string[] d)
        {
            Value = new float[4];
            if (float.TryParse(d[0], out float res1)) Value[0] = res1;
            if (float.TryParse(d[1], out float res2)) Value[1] = res2;
            if (float.TryParse(d[2], out float res3)) Value[2] = res3;
            if (float.TryParse(d[3], out float res4)) Value[3] = res4;
        }

        public override string ToString()
        {
            string oup = "(";
            for (int i = 0; i < Value.Length; i++)
            {
                oup += Convert.ToString(Value[i]) + ", ";
            }
            return oup.Remove(oup.Length - 2) + ")";
        }
    }
}