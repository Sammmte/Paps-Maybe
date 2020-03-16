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

        public static Maybe<T> ToMaybeEmptyIfNull<T>(this T value) where T : class
        {
            return value == null ? Maybe<T>.Nothing : new Maybe<T>(value);
        }

        public static T GetOrElse<T>(this Maybe<T> maybe, Func<T> getter)
        {
            if (maybe.HasValue) return maybe.Value;
            else return getter();
        }

        public static Maybe<T> ToMaybeEmptyIfMatches<T>(this T value, T nothingValue, IEqualityComparer<T> equalityComparer)
        {
            if (equalityComparer.Equals(value, nothingValue))
            {
                return Maybe<T>.Nothing;
            }

            return new Maybe<T>(value);
        }

        public static Maybe<T> ToMaybeEmptyIfMatches<T>(this T value, T nothingValue)
        {
            return ToMaybeEmptyIfMatches(value, nothingValue, EqualityComparer<T>.Default);
        }

        public static bool IsNothing<T>(this Maybe<T> maybe)
        {
            return maybe.HasValue == false;
        }

        public static bool IsSomething<T>(this Maybe<T> maybe)
        {
            return maybe.HasValue;
        }
    }

}