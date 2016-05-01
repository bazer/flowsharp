using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public struct Option<T> : IEnumerable<T>, IEquatable<Option<T>>
        where T : class
    {
        private readonly T value;

        private Option(T value)
        {
            this.value = value;
        }

        public bool HasValue => value != null;

        public T Unwrap(T defaultValue = default(T))
        {
            if (HasValue)
                return value;

            return defaultValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Option<T> other)
        {
            if (!HasValue && !other.HasValue)
                return true;

            if (!HasValue || !other.HasValue)
                return false;

            return value.Equals(other.value);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static implicit operator Option<T>(T value)
        {
            return new Option<T>(value);
        }

        public static bool operator ==(Option<T> option, T value)
        {
            if (!option.HasValue)
                return false;

            return option.value.Equals(value);
        }

        public static bool operator !=(Option<T> option, T value)
        {
            return !(option == value);
        }

        public static bool operator ==(Option<T> a, Option<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Option<T> a, Option<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            if (!HasValue)
                return "No value";

            return value.ToString(); 
        }
    }
}
