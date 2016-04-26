//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FlowSharp
//{
//    public static class SingleFlowExtensions
//    {
//        public static SingleFlow<O> IfStopped<O>(this SingleFlow<O> flow, Action<O> func)
//        {
//            if (flow.IsStopped)
//                func(flow.Value);

//            return flow;
//        }

//        public static SingleFlow<O> IfFlowing<O>(this SingleFlow<O> flow, Action<O> func)
//        {
//            if (!flow.IsStopped)
//                func(flow.Value);

//            return flow;
//        }

//        public static SingleFlow<O> Flow<O>(this O value)
//        {
//            return SingleFlow<O>.Flow(value);
//        }

//        public static SingleFlow<O> Flow<O>(this O value, Func<SingleFlow<O>> func)
//        {
//             return Flow(func());
//        }

//        public static SingleFlow<O> Flow<O>(this O value, Func<O, SingleFlow<O>> func)
//        {
//            return Flow(func(value));
//        }

//        public static SingleFlow<O> Stop<O>(this O value)
//        {
//            return SingleFlow<O>.Stop(value);
//        }

//        private static SingleFlow<O> Flow<O>(this SingleFlow<O> flow)
//        {
//            if (flow.IsStopped)
//                SingleFlow<O>.Stop(flow.Value);

//            return SingleFlow<O>.Flow(flow.Value);
//        }

//        //public static SingleFlow<O> Flow<I, O>(this SingleFlow<I> flow, Func<SingleFlow<O>> func, Func<I, O> convertFailure)
//        //{
//        //    if (flow.IsStopped)
//        //        return SingleFlow<O>.Stop(convertFailure(flow.Value));

//        //    return Flow(func());
//        //}

//        //public static SingleFlow<O> Flow<I, O>(this SingleFlow<I> flow, Func<I, SingleFlow<O>> func, Func<I, O> convertFailure)
//        //{
//        //    if (flow.IsStopped)
//        //        return SingleFlow<O>.Stop(convertFailure(flow.Value));

//        //    return Flow(func(flow.Value));
//        //}

//        //public static SingleFlow<O> I<I, O>(this SingleFlow<I> flow, Func<I, SingleFlow<O>> func, Func<I, O> convertFailure)
//        //{
//        //    if (flow.IsStopped)
//        //        return SingleFlow<O>.Stop(convertFailure(flow.Value));

//        //    return Flow(func(flow.Value));
//        //}

//        public static SingleFlow<O> Flow<O>(this SingleFlow<O> flow, Func<SingleFlow<O>> func)
//        {
//            if (flow.IsStopped)
//                return flow;

//            return Flow(func());
//        }

//        public static SingleFlow<O> Flow<O>(this SingleFlow<O> flow, Func<O, SingleFlow<O>> func)
//        {
//            if (flow.IsStopped)
//                return flow;

//            return Flow(func(flow.Value));
//        }

//        public static SingleFlow<O> I<O>(this SingleFlow<O> flow, Func<O, SingleFlow<O>> func)
//        {
//            if (flow.IsStopped)
//                return flow;

//            return Flow(func(flow.Value));
//        }
//    }
//}
