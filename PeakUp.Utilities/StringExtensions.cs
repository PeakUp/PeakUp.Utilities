using PeakUp.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PeakUp.Utilities
{
    public static class StringExtensions
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public static bool IsNullOrEmpty(this string self) => string.IsNullOrEmpty(self);

        public static bool IsNullOrWhiteSpace(this string self) => string.IsNullOrWhiteSpace(self);

        public static int ToInt(this string self)
        {
            int i = 0;
            int.TryParse(self, out i);
            return i;
        }

        public static double ToDouble(this string self)
        {
            double d = 0.0;
            double.TryParse(self, out d);
            return d;
        }

        public static DateTime ToDateTime(this string self)
        {
            DateTime dt = DateTime.MinValue;
            DateTime.TryParse(self, out dt);
            return dt;
        }

        public static DateTimeOffset ToDateTimeOffset(this string self)
        {
            DateTimeOffset dto = DateTimeOffset.MinValue;
            DateTimeOffset.TryParse(self, out dto);
            return dto;
        }

        static Dictionary<Type, Func<string, object>> Converters = new Dictionary<Type, Func<string, object>> {
            { typeof(int), s => s.ToInt() },
            { typeof(double), s => s.ToDouble() },
            { typeof(DateTime), s => s.ToDateTime() },
            { typeof(DateTimeOffset), s => s.ToDateTimeOffset() }
        };

        public static T To<T>(this string self)
        {
            var converter = Converters.TryGetValue(typeof(T));
            if (converter == null) throw new NotSupportedException();
            return converter(self).As(o => o == null ? default(T) : (T)o);
        }
       
        public static string HMAC(this string self, string key, HashType hashType = HashType.MD5)
        {
            switch (hashType)
            {
                case HashType.RPEMD160:
                    return self.HMACAsRPEMD160(key);                    
                case HashType.MD5:
                    return self.HMACAsMD5(key);
                case HashType.SHA1:
                    return self.HMACAsSHA1(key);
                case HashType.SHA256:
                    return self.HMACAsSHA256(key);
                case HashType.SHA384:
                    return self.HMACAsSHA384(key);
                case HashType.SHA512:
                    return self.HMACAsSHA512(key);
                default:
                    return self.HMACAsMD5(key);
            }
        }


        public static string HMACAsRPEMD160(this string self, string key)
        {
            var keyByte = encoding.GetBytes(key);
            using (var hmacsha256 = new HMACRIPEMD160(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(self));
                return hmacsha256.Hash.ConvertString().ToLower();
            }
        }

        public static string HMACAsMD5(this string self, string key)
        {
            var keyByte = encoding.GetBytes(key);
            using (var hmacsha256 = new HMACMD5(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(self));
                return hmacsha256.Hash.ConvertString().ToLower();
            }
        }

        public static string HMACAsSHA1(this string self, string key)
        {
            var keyByte = encoding.GetBytes(key);
            using (var hmacsha256 = new HMACSHA1(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(self));
                return hmacsha256.Hash.ConvertString().ToLower();
            }
        }

        public static string HMACAsSHA256(this string self, string key)
        {
            var keyByte = encoding.GetBytes(key);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(self));
                return hmacsha256.Hash.ConvertString().ToLower();
            }
        }

        public static string HMACAsSHA384(this string self, string key)
        {
            var keyByte = encoding.GetBytes(key);
            using (var hmacsha256 = new HMACSHA384(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(self));
                return hmacsha256.Hash.ConvertString().ToLower();
            }
        }

        public static string HMACAsSHA512(this string self, string key)
        {
            var keyByte = encoding.GetBytes(key);
            using (var hmacsha256 = new HMACSHA512(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(self));
                return hmacsha256.Hash.ConvertString().ToLower();
            }
        }

    }
}
