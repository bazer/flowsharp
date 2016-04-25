using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public interface ISideFlow<V, S> : IFlow
    {
        V Value { get; }
        S SideValue { get; }
        ISideFlow<T, S> Convert<T>();
    }

    public class SideFlow<V, S> : ISideFlow<V, S>
    {
        public V Value { get; }
        public S SideValue { get; }
        public bool IsStopped { get; }

        protected SideFlow(V value)
        {
            this.Value = value;
            this.IsStopped = false;
        }

        protected SideFlow(S sideValue)
        {
            this.SideValue = sideValue;
            this.IsStopped = true;
        }

        public static SideFlow<V, S> Flow(V value)
        {
            return new SideFlow<V, S>(value);
        }

        public static SideFlow<V, S> Stop(S sideValue)
        {
            return new SideFlow<V, S>(sideValue);
        }

        //public static SideFlow<V, S> Continue(S sideValue)
        //{
        //    return new SideFlow<V, S>(sideValue);
        //}

        public ISideFlow<T, S> Convert<T>()
        {
            throw new NotImplementedException();
        }
    }

}
