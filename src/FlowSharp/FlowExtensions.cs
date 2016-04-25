using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class FlowExtensions
    {


        private static IFlowValue<T> FailOnValue<T>(this T value, T failValue)
        {
            if ((value == null && failValue == null) || value.Equals(failValue))
                return FlowValue<T>.Fail(value);

            return FlowValue<T>.Flow(value);
        }

        public static IFlowValue<T> FailOnValue<T>(this IFlowValue<T> flow, Func<T, T> func, T failValue)
        {
            if (flow.IsFailed)
                return FlowValue<T>.Fail(flow.Value);

            return FailOnValue(func(flow.Value), failValue);
        }

        public static IFlowValue<T> FailOnValue<T>(this IFlowValue<T> flow, Func<T> func, T failValue)
        {
            if (flow.IsFailed)
                return FlowValue<T>.Fail(flow.Value);

            return FailOnValue(func(), failValue);
        }

        public static IFlowValue<O> FailOnValue<I, O>(this IFlowValue<I> flow, Func<I, O> func, O failValue, Func<I, O> convertFailure)
        {
            if (flow.IsFailed)
                return FlowValue<O>.Fail(convertFailure(flow.Value));

            return FailOnValue(func(flow.Value), failValue);
        }

        public static IFlowValue<O> FailOnValue<I, O>(this IFlowValue<I> flow, Func<O> func, O failValue, Func<I, O> convertFailure)
        {
            if (flow.IsFailed)
                return FlowValue<O>.Fail(convertFailure(flow.Value));

            return FailOnValue(func(), failValue);
        }

        public static IFlowValue<O> AsFlow<O>(this O value)
        {
            return FlowSharp.AsFlow(value);
        }

        public static IFlowValue<O> AsFail<O>(this O value)
        {
            return FlowSharp.AsFail(value);
        }

        public static IFlowValue<O> Flow<O>(this O value, Func<O, IFlowValue<O>> func)
        {
            return Flow(func(value));
        }

        //public static IFlowValue<O> Flow<I, O>(this I value, Func<I, IFlowValue<O>> func)// where I : IFlowValue<I>
        //{
        //    return Flow(func(value));
        //}

        private static IFlowValue<O> Flow<O>(this IFlowValue<O> flow)
        {
            if (flow.IsFailed)
                FlowValue<O>.Fail(flow.Value);

            return FlowValue<O>.Flow(flow.Value);
        }

        public static IFlowValue<O> Flow<I, O>(this IFlowValue<I> flow, Func<IFlowValue<O>> func, Func<I, O> convertFailure)
        {
            if (flow.IsFailed)
                return FlowValue<O>.Fail(convertFailure(flow.Value));

            return Flow(func());
        }

        public static IFlowValue<O> Flow<I, O>(this IFlowValue<I> flow, Func<I, IFlowValue<O>> func, Func<I, O> convertFailure)
        {
            if (flow.IsFailed)
                return FlowValue<O>.Fail(convertFailure(flow.Value));

            return Flow(func(flow.Value));
        }

        public static IFlowValue<O> Flow<O>(this IFlowValue<O> flow, Func<IFlowValue<O>> func)
        {
            if (flow.IsFailed)
                return FlowValue<O>.Fail(flow.Value);

            return Flow(func());
        }

        public static IFlowValue<O> Flow<O>(this IFlowValue<O> flow, Func<O, IFlowValue<O>> func)
        {
            if (flow.IsFailed)
                return FlowValue<O>.Fail(flow.Value);

            return Flow(func(flow.Value));
        }

        public static IFlowValue<O> HandleFailure<O>(this IFlowValue<O> flow, Action<O> func)
        {
            if (flow.IsFailed)
                func(flow.Value);

            return FlowValue<O>.Flow(flow.Value);
        }
    }
}
