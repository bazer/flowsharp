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
        //ISingleFlow<V> Flow(V value);
        //ISingleFlow<V> Stop(V value);
    }

    public interface ISingleFlow<V, T> : ISingleFlow<V>
    {
        //V Value { get; }
        T Flow(V value);
        T Stop(V value);
    }
}
