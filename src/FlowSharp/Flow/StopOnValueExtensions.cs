using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class StopOnValueExtensions
    {
        private static ISingleFlow<T> StopOnValue<T>(this T value, T failValue)
        {
            if ((value == null && failValue == null) || value.Equals(failValue))
                return SingleFlow<T>.Stop(value);

            return SingleFlow<T>.Flow(value);
        }

        public static ISingleFlow<T> StopOnValue<T>(this ISingleFlow<T> flow, Func<T, T> func, T failValue)
        {
            if (flow.IsStopped)
                return flow;

            return StopOnValue(func(flow.Value), failValue);
        }

        public static ISingleFlow<T> StopOnValue<T>(this ISingleFlow<T> flow, Func<T> func, T failValue)
        {
            if (flow.IsStopped)
                return flow;

            return StopOnValue(func(), failValue);
        }

        public static ISingleFlow<O> StopOnValue<I, O>(this ISingleFlow<I> flow, Func<I, O> func, O failValue, Func<I, O> convertFailure)
        {
            if (flow.IsStopped)
                return SingleFlow<O>.Stop(convertFailure(flow.Value));

            return StopOnValue(func(flow.Value), failValue);
        }

        public static ISingleFlow<O> StopOnValue<I, O>(this ISingleFlow<I> flow, Func<O> func, O failValue, Func<I, O> convertFailure)
        {
            if (flow.IsStopped)
                return SingleFlow<O>.Stop(convertFailure(flow.Value));

            return StopOnValue(func(), failValue);
        }
    }
}
