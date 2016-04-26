using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class SingleFlowFlow
    {
        private static SingleFlow<O> Parse<O>(this SingleFlow<O> flow)
        {
            if (flow.IsStopped)
                flow.Stop(flow.Value);

            return flow.Flow(flow.Value);
        }

        public static SingleFlow<O> Flow<O>(this SingleFlow<O> flow, Func<SingleFlow<O>> func)
        {
            if (flow.IsStopped)
                return flow;

            return Parse(func());
        }

        public static SingleFlow<O> Flow<O>(this SingleFlow<O> flow, Func<O, SingleFlow<O>> func)
        {
            if (flow.IsStopped)
                return flow;

            return Parse(func(flow.Value));
        }

        //public static ISingleFlow<O> Flow<I, O>(this ISingleFlow<I> flow, Func<ISingleFlow<O>> func, Func<I, O> convertFailure)
        //{
        //    if (flow.IsStopped)
        //        return flow.Stop(convertFailure(flow.Value));

        //    return Flow(func());
        //}

        //public static ISingleFlow<O> Flow<I, O>(this ISingleFlow<I> flow, Func<I, ISingleFlow<O>> func, Func<I, O> convertFailure)
        //{
        //    if (flow.IsStopped)
        //        return SingleFlow<O>.Stop(convertFailure(flow.Value));

        //    return Flow(func(flow.Value));
        //}

        //public static ISingleFlow<O> I<I, O>(this ISingleFlow<I> flow, Func<I, ISingleFlow<O>> func, Func<I, O> convertFailure)
        //{
        //    if (flow.IsStopped)
        //        return SingleFlow<O>.Stop(convertFailure(flow.Value));

        //    return Flow(func(flow.Value));
        //}
    }
}
