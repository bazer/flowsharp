using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class SideFlowExtensions
    {
        public static ISideFlow<O, F> SideFlow<O, F>(this O value)
        {
            return global::FlowSharp.SideFlow<O, F>.Flow(value);
        }

        private static ISideFlow<O, F> Flow<O, F>(this ISideFlow<O, F> flow)
        {
            if (flow.IsStopped)
                global::FlowSharp.SideFlow<O, F>.Stop(flow.SideValue);

            return global::FlowSharp.SideFlow<O, F>.Flow(flow.Value);
        }

        public static ISideFlow<O, F> Flow<I, O, F>(this ISideFlow<I, F> flow, Func<ISideFlow<O, F>> func)
        {
            if (flow.IsStopped)
                return global::FlowSharp.SideFlow<O, F>.Stop(flow.SideValue);

            return Flow(func());
        }

        public static ISideFlow<O, F> Flow<I, O, F>(this ISingleFlow<I> flow, Func<ISideFlow<O, F>> func, Func<I, F> convertFailure)
        {
            if (flow.IsStopped)
                return global::FlowSharp.SideFlow<O, F>.Stop(convertFailure(flow.Value));

            return Flow(func());
        }

        public static ISideFlow<O, F> OnFail<O, F>(this ISideFlow<O, F> flow, Action<F> func)
        {
            if (flow.IsStopped)
                func(flow.SideValue);

            return global::FlowSharp.SideFlow<O, F>.Flow(flow.Value);
        }
    }
}
