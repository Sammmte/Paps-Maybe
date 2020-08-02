using System;
using System.Collections.Generic;

namespace Paps.Maybe
{
    public readonly struct Maybe<T> : IEquatable<Maybe<T>>
    {
        private readonly IEqualityComparer<T> _equalityComparer;

        public readonly bool HasValue;

        private readonly T _value;

        private readonly int _hashCode;

        public T Value
        {
            get
            {
                if (HasValue == false)
                    throw new InvalidOperationException("Value is not present");

                return _value;
            }
        }

        public Maybe(T value, IEqualityComparer<T> equalityComparer)
        {
            _equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;

            if (value != null)
                HasValue = true;
            else
                HasValue = false;

            _value = value;
            _hashCode = GenerateHashCode(HasValue, _value, _equalityComparer);
        }

        public Maybe(T value) : this(value, EqualityComparer<T>.Default)
        {

        }

        private static int GenerateHashCode(bool hasValue, T value, IEqualityComparer<T> equalityComparer)
        {
            unchecked
            {
                var hashCode = 13;
                hashCode = (hashCode * 397) ^ hasValue.GetHashCode();
                hashCode = (hashCode * 397) ^ equalityComparer.GetHashCode(value);

                return hashCode;
            }
        }

        public override bool Equals(object obj)
        {
            if(obj is Maybe<T> maybe)
            {
                return Equals(maybe);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }

        public bool Equals(Maybe<T> other)
        {
            if(HasValue == other.HasValue)
            {
                if(_equalityComparer == null) 
                    return EqualityComparer<T>.Default.Equals(_value, other._value);
                else 
                    return _equalityComparer.Equals(_value, other._value);
            }

            return false;
        }

        public static bool operator ==(Maybe<T> maybe1, Maybe<T> maybe2)
        {
            return maybe1.Equals(maybe2);
        }

        public static bool operator !=(Maybe<T> maybe1, Maybe<T> maybe2)
        {
            return !maybe2.Equals(maybe2);
        }

        public static Maybe<T> Nothing => new Maybe<T>();

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }
    }
}
