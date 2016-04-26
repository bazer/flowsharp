using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class ISingleFlowControl
    {
        public static ISingleFlow<O> IfStopped<O>(this ISingleFlow<O> flow, Action<O> func)
        {
            if (flow.IsStopped)
                func(flow.Value);

            return flow;
        }

        public static ISingleFlow<O> IfFlowing<O>(this ISingleFlow<O> flow, Action<O> func)
        {
            if (!flow.IsStopped)
                func(flow.Value);

            return flow;
        }
    }
}
