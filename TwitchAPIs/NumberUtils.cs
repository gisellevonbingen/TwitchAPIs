using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs
{
    public static class NumberUtils
    {
        public static bool? ToBoolNullable(string s)
        {
            return bool.TryParse(s, out bool result) ? new bool?(result) : null;
        }

        public static bool ToBool(string s, bool fallback)
        {
            return bool.TryParse(s, out bool result) ? result : fallback;
        }

        public static bool ToBool(string s)
        {
            return ToBool(s, false);
        }

        public static byte? ToByteNullable(string s)
        {
            return byte.TryParse(s, out byte result) ? new byte?(result) : null;
        }

        public static byte ToByte(string s, byte fallback)
        {
            return byte.TryParse(s, out byte result) ? result : fallback;
        }

        public static byte ToByte(string s)
        {
            return ToByte(s, 0);
        }

        public static sbyte? ToSByteNullable(string s)
        {
            return sbyte.TryParse(s, out sbyte result) ? new sbyte?(result) : null;
        }

        public static sbyte ToSByte(string s, sbyte fallback)
        {
            return sbyte.TryParse(s, out sbyte result) ? result : fallback;
        }

        public static sbyte ToSByte(string s)
        {
            return ToSByte(s, 0);
        }

        public static short? ToShortNullable(string s)
        {
            return short.TryParse(s, out short result) ? new short?(result) : null;
        }

        public static short ToShort(string s, short fallback)
        {
            return short.TryParse(s, out short result) ? result : fallback;
        }

        public static short ToShort(string s)
        {
            return ToShort(s, 0);
        }

        public static ushort? ToUShortNullable(string s)
        {
            return ushort.TryParse(s, out ushort result) ? new ushort?(result) : null;
        }

        public static ushort ToUShort(string s, ushort fallback)
        {
            return ushort.TryParse(s, out ushort result) ? result : fallback;
        }

        public static ushort ToUShort(string s)
        {
            return ToUShort(s, 0);
        }

        public static int? ToIntNullable(string s)
        {
            return int.TryParse(s, out int result) ? new int?(result) : null;
        }

        public static int ToInt(string s, int fallback)
        {
            return int.TryParse(s, out int result) ? result : fallback;
        }

        public static int ToInt(string s)
        {
            return ToInt(s, 0);
        }

        public static uint? ToUIntNullable(string s)
        {
            return uint.TryParse(s, out uint result) ? new uint?(result) : null;
        }

        public static uint ToUInt(string s, uint fallback)
        {
            return uint.TryParse(s, out uint result) ? result : fallback;
        }

        public static uint ToUInt(string s)
        {
            return ToUInt(s, 0);
        }

        public static long? ToLongNullable(string s)
        {
            return long.TryParse(s, out long result) ? new long?(result) : null;
        }

        public static long ToLong(string s, long fallback)
        {
            return long.TryParse(s, out long result) ? result : fallback;
        }

        public static long ToLong(string s)
        {
            return ToLong(s, 0);
        }

        public static ulong? ToULongNullable(string s)
        {
            return ulong.TryParse(s, out ulong result) ? new ulong?(result) : null;
        }

        public static ulong ToULong(string s, ulong fallback)
        {
            return ulong.TryParse(s, out ulong result) ? result : fallback;
        }

        public static ulong ToULong(string s)
        {
            return ToULong(s, 0);
        }

        public static float? ToFloatNullable(string s)
        {
            return float.TryParse(s, out float result) ? new float?(result) : null;
        }

        public static float ToFloat(string s, float fallback)
        {
            return float.TryParse(s, out float result) ? result : fallback;
        }

        public static float ToFloat(string s)
        {
            return ToFloat(s, 0);
        }

        public static double? ToDoubleNullable(string s)
        {
            return double.TryParse(s, out double result) ? new double?(result) : null;
        }

        public static double ToDouble(string s, double fallback)
        {
            return double.TryParse(s, out double result) ? result : fallback;
        }

        public static double ToDouble(string s)
        {
            return ToDouble(s, 0);
        }

    }

}
