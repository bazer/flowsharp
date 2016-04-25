using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    

    public interface ISingleFlow<V> : IFlow
    {
        V Value { get; }
    }

    public class SingleFlow<V> : ISingleFlow<V>
    {
        public V Value { get; }
        public bool IsStopped { get; }

        private SingleFlow(V value, bool isStopped)
        {
            this.Value = value;
            this.IsStopped = isStopped;
        }

        public static SingleFlow<V> Flow(V value)
        {
            return new SingleFlow<V>(value, false);
        }

        public static SingleFlow<V> Stop(V value)
        {
            return new SingleFlow<V>(value, true);
        }
    }
}
