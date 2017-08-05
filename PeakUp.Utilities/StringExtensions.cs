using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakUp.Utilities
{
    public static class StringExtensions
    {
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
    }
}
