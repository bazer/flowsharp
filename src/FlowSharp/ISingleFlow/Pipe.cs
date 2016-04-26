using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class ISingleFlowPipe
    {
        private static ISingleFlow<O> Parse<O>(this ISingleFlow<O, ISingleFlow<O>> flow)
        {
            if (flow.IsStopped)
                flow.Stop(flow.Value);

            return flow.Flow(flow.Value);
        }

        public static ISingleFlow<O> I<O>(this ISingleFlow<O> flow, Func<ISingleFlow<O, ISingleFlow<O>>> func)
        {
            if (flow.IsStopped)
                return flow;

            return Parse(func());
        }

        public static ISingleFlow<O> I<O>(this ISingleFlow<O> flow, Func<O, ISingleFlow<O, ISingleFlow<O>>> func)
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
