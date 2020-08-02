using System;
using System.Collections.Generic;

namespace Paps.Maybe
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<T> AsNothing<T>(this T value)
        {
            return Maybe<T>.Nothing;
        }

        public static Maybe<T> AsNothingWhen<T>(this T value, Func<bool> predicate)
        {
            if (predicate())
                return Maybe<T>.Nothing;
            else
                return value.ToMaybe();
        }

        public static T GetOrDefault<T>(this Maybe<T> maybe, T defaultValue)
        {
            if (maybe.HasValue) return maybe.Value;
            else return defaultValue;
        }

        public static bool IsNothing<T>(this Maybe<T> maybe)
        {
            return maybe.HasValue == false;
        }

        public static bool IsSomething<T>(this Maybe<T> maybe)
        {
            return maybe.HasValue;
        }

        public static Maybe<T> Do<T>(this Maybe<T> maybe, Action<T> action)
        {
            if (maybe.IsSomething())
                action(maybe.Value);

            return maybe;
        }

        public static void OrElse<T>(this Maybe<T> maybe, Action action)
        {
            if (maybe.IsNothing())
                action();
        }
    }

}