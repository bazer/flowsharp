using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class SingleFlowStopOnValue
    {
        private static SingleFlow<T> Parse<T>(SingleFlow<T> flow, T value, T failValue)
        {
            if ((value == null && failValue == null) || value.Equals(failValue))
                return flow.Stop(value);

            return flow.Flow(value);
        }

        public static SingleFlow<T> StopOnValue<T>(this SingleFlow<T> flow, Func<T, T> func, T failValue)
        {
            if (flow.IsStopped)
                return flow;

            return Parse(flow, func(flow.Value), failValue);
        }

        public static SingleFlow<T> StopOnValue<T>(this SingleFlow<T> flow, Func<T> func, T failValue)
        {
            if (flow.IsStopped)
                return flow;

            return Parse(flow, func(), failValue);
        }

        //public static ISingleFlow<O> StopOnValue<I, O>(this ISingleFlow<I> flow, Func<I, O> func, O failValue, Func<I, O> convertFailure)
        //{
        //    if (flow.IsStopped)
        //        return SingleFlow<O>.Stop(convertFailure(flow.Value));

        //    return Parse(func(flow.Value), failValue);
        //}

        //public static ISingleFlow<O> StopOnValue<I, O>(this ISingleFlow<I> flow, Func<O> func, O failValue, Func<I, O> convertFailure)
        //{
        //    if (flow.IsStopped)
        //        return SingleFlow<O>.Stop(convertFailure(flow.Value));

        //    return Parse(func(), failValue);
        //}
    }
}
