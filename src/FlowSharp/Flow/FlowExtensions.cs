using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class FlowExtensions
    {
        private static ISingleFlow<O> Flow<O>(this ISingleFlow<O> flow)
        {
            if (flow.IsStopped)
                SingleFlow<O>.Stop(flow.Value);

            return SingleFlow<O>.Flow(flow.Value);
        }

        public static ISingleFlow<O> Flow<I, O>(this ISingleFlow<I> flow, Func<ISingleFlow<O>> func, Func<I, O> convertFailure)
        {
            if (flow.IsStopped)
                return SingleFlow<O>.Stop(convertFailure(flow.Value));

            return Flow(func());
        }

        public static ISingleFlow<O> Flow<I, O>(this ISingleFlow<I> flow, Func<I, ISingleFlow<O>> func, Func<I, O> convertFailure)
        {
            if (flow.IsStopped)
                return SingleFlow<O>.Stop(convertFailure(flow.Value));

            return Flow(func(flow.Value));
        }

        public static ISingleFlow<O> I<I, O>(this ISingleFlow<I> flow, Func<I, ISingleFlow<O>> func, Func<I, O> convertFailure)
        {
            if (flow.IsStopped)
                return SingleFlow<O>.Stop(convertFailure(flow.Value));

            return Flow(func(flow.Value));
        }

        public static ISingleFlow<O> Flow<O>(this ISingleFlow<O> flow, Func<ISingleFlow<O>> func)
        {
            if (flow.IsStopped)
                return flow;

            return Flow(func());
        }

        public static ISingleFlow<O> Flow<O>(this ISingleFlow<O> flow, Func<O, ISingleFlow<O>> func)
        {
            if (flow.IsStopped)
                return flow;

            return Flow(func(flow.Value));
        }

        public static ISingleFlow<O> I<O>(this ISingleFlow<O> flow, Func<O, ISingleFlow<O>> func)
        {
            if (flow.IsStopped)
                return flow;

            return Flow(func(flow.Value));
        }
    }
}
