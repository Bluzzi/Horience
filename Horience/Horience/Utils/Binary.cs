using System;

namespace Horience.Utils
{
    class Binary
    {
        
        public static long SignByte(long value)
        {
            return value << 56 >> 56;
        }

        public static long UnsignByte(long value)
        {
            return value & 0xff;
        }

        public static long SignShort(long value)
        {
            return value << 48 >> 48;
        }

        public static long UnsignShort(long value)
        {
            return value & 0xffff;
        }

        public static long SignInt(long value)
        {
            return value << 32 >> 32;
        }

        public static long UnsignInt(long value)
        {
            return value & 0xffffffff;
        }

        public static bool ReadBool(string b)
        {
            return !(b == "\0");
        }

        public static string WriteBool(bool b)
        {
            return !b ? "\0" : "\u0001";
        }

        public static long ReadByte(string c)
        {
            return (int) c[0];
        }

        public static long ReadSignedByte(string c)
        {
            return SignByte((int) c[0]);
        }

        public static char WriteByte(long c)
        {
            return Convert.ToChar(c);
        }

        public static long ReadInt(byte[] bytes)
        {
            return ((bytes[0] & 0xff) << 24) + ((bytes[1] & 0xff) << 16) + ((bytes[2] & 0xff) << 8) + (bytes[3] & 0xff);
        }
        public static long ReadTriad(byte[] bytes)
        {
            return ReadInt(new byte[] { (byte)0x00, bytes[0], bytes[1], bytes[2] });
        }
    }
}
