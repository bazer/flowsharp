using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public interface IFlowValue<V>
    {
        V Value { get; }
        bool IsFailed { get; }
    }

    public interface IFlowValue<V, F> : IFlowValue<V>
    {
        F Failure { get; }
        IFlowValue<T, F> Convert<T>();
    }

    public class FlowValue<V> : IFlowValue<V>
    {
        public V Value { get; }
        public bool IsFailed { get; }

        private FlowValue(V value, bool isSwitched)
        {
            this.Value = value;
            this.IsFailed = isSwitched;
        }

        public static FlowValue<V> Flow(V value)
        {
            return new FlowValue<V>(value, false);
        }

        public static FlowValue<V> Fail(V value)
        {
            return new FlowValue<V>(value, true);
        }
    }

    public class FlowValue<V, F> : IFlowValue<V, F>
    {
        public V Value { get; }
        public F Failure { get; }
        public bool IsFailed { get; }

        protected FlowValue(V value)
        {
            this.Value = value;
            this.IsFailed = false;
        }

        protected FlowValue(F failure)
        {
            this.Failure = failure;
            this.IsFailed = true;
        }

        public static FlowValue<V, F> Flow(V value)
        {
            return new FlowValue<V, F>(value);
        }

        public static FlowValue<V, F> Fail(F value)
        {
            return new FlowValue<V, F>(value);
        }

        public IFlowValue<T, F> Convert<T>()
        {
            throw new NotImplementedException();
        }
    }

}
