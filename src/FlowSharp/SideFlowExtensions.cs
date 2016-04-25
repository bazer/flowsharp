using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class SideFlowExtensions
    {
        public static IFlowValue<O, F> SideFlow<O, F>(this O value)
        {
            return FlowSharp.SideFlow<O, F>(value);
        }

        private static IFlowValue<O, F> Flow<O, F>(this IFlowValue<O, F> flow)
        {
            if (flow.IsFailed)
                FlowValue<O, F>.Fail(flow.Failure);

            return FlowValue<O, F>.Flow(flow.Value);
        }

        public static IFlowValue<O, F> Flow<I, O, F>(this IFlowValue<I, F> flow, Func<IFlowValue<O, F>> func)
        {
            if (flow.IsFailed)
                return FlowValue<O, F>.Fail(flow.Failure);

            return Flow(func());
        }

        public static IFlowValue<O, F> Flow<I, O, F>(this IFlowValue<I> flow, Func<IFlowValue<O, F>> func, Func<I, F> convertFailure)
        {
            if (flow.IsFailed)
                return FlowValue<O, F>.Fail(convertFailure(flow.Value));

            return Flow(func());
        }

        public static IFlowValue<O, F> OnFail<O, F>(this IFlowValue<O, F> flow, Action<F> func)
        {
            if (flow.IsFailed)
                func(flow.Failure);

            return FlowValue<O, F>.Flow(flow.Value);
        }
    }
}
