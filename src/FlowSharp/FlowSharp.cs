using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public class FlowSharp
    {
        public static IFlowValue<V> AsFlow<V>(V value)
        {
            return FlowValue<V>.Flow(value);
        }

        public static IFlowValue<V> AsFail<V>(V value)
        {
            return FlowValue<V>.Flow(value);
        }

        public static IFlowValue<V, F> SideFlow<V, F>(V value)
        {
            return FlowValue<V, F>.Flow(value);
        }

        public static IFlowValue<V, F> SideFail<V, F>(F value)
        {
            return FlowValue<V, F>.Fail(value);
        }
    }
}
