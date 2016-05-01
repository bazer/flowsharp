using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class SideFlowExtensions
    {
        private static Y SideFlow<O, F, Y>(this Y flow)
            //where T : ISideFlow<O, F, T>
            where Y : ISideFlow<O, F>
        {
            if (flow.IsStopped)
                return (Y)flow.Stop<Y>(flow.SideValue);

            return (Y)flow.Flow(flow.Value);
        }

        public static T SideFlow<T>(this T flow, Func<T> func)
        where T : IFlow
            //where Y : ISideFlow<O, F>
        {
            if (flow.IsStopped)
                return flow;
            //return flow.Stop<I>(flow.SideValue);

            return func();

            //return SideFlow<I, F, ISideFlow<I, F>>(func());
        }

        public static ISideFlow<I, F> SideFlow<I, F>(this ISideFlow<I, F> flow, Func<ISideFlow<I, F>> func)
            //where T : ISideFlow<I, F>
            //where Y : ISideFlow<O, F>
        {
            if (flow.IsStopped)
                return flow;
                //return flow.Stop<I>(flow.SideValue);

            return SideFlow<I, F, ISideFlow<I, F>>(func());
        }

        public static Y SideFlow<I, O, F, Y>(this ISideFlow<I, F> flow, Func<Y> func)
            //where T : ISideFlow<I, F>
            where Y : ISideFlow<O, F>
        {
            if (flow.IsStopped)
                return (Y)flow.Stop<Y>(flow.SideValue);

            return SideFlow<O, F, Y>(func());
        }

        //public static Y SideFlow<I, O, F, T, Y>(this T flow, Func<Y> func) 
        //    where T : ISideFlow<I, F, T>
        //    where Y : ISideFlow<O, F, Y>
        //{
        //    if (flow.IsStopped)
        //        return flow.Stop<Y>(flow.SideValue);

        //    return SideFlow<O, F, Y>(func());
        //}

        //public static T SideFlow<O, F, T>(this O value)
        //    where T : ISideFlow<O, F, T>
        //{
        //    return new global::FlowSharp.SideFlow<O, F>.Flow(value);
        //}

        //private static Y SideFlow<O, F, Y>(this Y flow)
        //    //where T : ISideFlow<O, F, T>
        //    where Y : ISideFlow<O, F, Y>
        //{
        //    if (flow.IsStopped)
        //        flow.Stop<Y>(flow.SideValue);

        //    return flow.Flow<Y>(flow.Value);
        //}

        //public static Y SideFlow<I, O, F, T, Y>(this T flow, Func<Y> func)
        //    where T : ISideFlow<I, F, T>
        //    where Y : ISideFlow<O, F, Y>
        //{
        //    if (flow.IsStopped)
        //        return flow.Stop<Y>(flow.SideValue);

        //    return SideFlow<O, F, Y>(func());
        //}

        //public static ISideFlow<O, F> SideFlow<I, O, F>(this ISideFlow<I, F> flow, Func<ISideFlow<O, F>> func)
        //{
        //    if (flow.IsStopped)
        //        return global::FlowSharp.SideFlow<O, F>.Stop(flow.SideValue);

        //    return Flow(func());
        //}

        //public static ISideFlow<O, F> Flow<I, O, F>(this ISingleFlow<I> flow, Func<ISideFlow<O, F>> func, Func<I, F> convertFailure)
        //{
        //    if (flow.IsStopped)
        //        return global::FlowSharp.SideFlow<O, F>.Stop(convertFailure(flow.Value));

        //    return Flow(func());
        //}

        public static ISideFlow<O, F> OnFail<O, F>(this ISideFlow<O, F> flow, Action<F> func)
        {
            if (flow.IsStopped)
                func(flow.SideValue);

            return global::FlowSharp.SideFlow<O, F>.Flow(flow.Value);
        }
    }
}
