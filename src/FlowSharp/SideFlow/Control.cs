using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class ISideFlowControl
    {
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
        public static ISideFlow<V, S> IfStopped<V, S>(this ISideFlow<V, S> flow, Action<IEnumerable<S>> func)
        {
            if (flow.IsStopped)
                func(flow.SideValue);

            return flow;
        }

        public static ISideFlow<V, S> IfFlowing<V, S>(this ISideFlow<V, S> flow, Action<V> func)
        {
            if (!flow.IsStopped)
                func(flow.Value);

            return flow;
        }
    }
}
