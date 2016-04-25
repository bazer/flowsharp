using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class ControlExtensions
    {
        public static ISingleFlow<O> Flow<O>(this O value)
        {
            return SingleFlow<O>.Flow(value);
        }

        public static ISingleFlow<O> Stop<O>(this O value)
        {
            return SingleFlow<O>.Stop(value);
        }

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
