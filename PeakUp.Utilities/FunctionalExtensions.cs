using System;

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
    }
}
