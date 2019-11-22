using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeakUp.Utilities
{
    public static class FunctionalExtensions
    {
        public static T With<T>(this T self, Action<T> job)
        {
            job?.Invoke(self);
            return self;
        }

        public static TTo As<TFrom, TTo>(this TFrom self, Func<TFrom, TTo> job) => job == null ? default : job(self);

        public static bool IsNull<T>(this T self) where T : class => self == null;
        public static bool IsNull<T>(this T? self) where T : struct => !self.HasValue;
        public static bool IsNullOrEmpty(this string self) => string.IsNullOrEmpty(self);
        public static bool IsNullOrEmpty<T>(this IList<T> self) => self == null || self.Count == 0;
        public static bool IsNullOrEmpty(this IList self) => self == null || self.Count == 0;
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> self) => self == null || !self.Any();
        public static bool IsNullOrEmpty(this IEnumerable self) => self == null || !self.GetEnumerator().MoveNext();
    }
}
