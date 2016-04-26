using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class SingleFlowControl
    {
        public static SingleFlow<O> IfStopped<O>(this SingleFlow<O> flow, Action<O> func)
        {
            if (flow.IsStopped)
                func(flow.Value);

            return flow;
        }

        public static SingleFlow<O> IfFlowing<O>(this SingleFlow<O> flow, Action<O> func)
        {
            if (!flow.IsStopped)
                func(flow.Value);

            return flow;
        }
    }
}
