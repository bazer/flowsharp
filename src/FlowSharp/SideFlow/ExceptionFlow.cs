using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public class ExceptionFlow<V> : SideFlow<V, Exception>
    {
        public ExceptionFlow(params Exception[] e): base(e)
        {
        }

        public ExceptionFlow(V value): base(value)
        {
        }



        public ExceptionFlow<Y> ConvertTo<Y>() 
        {
            return new ExceptionFlow<Y>(this.SideValue.ToArray());
        }

    }

    public static class ExceptionFlowExtensions
    {
        public static ExceptionFlow<V> ExceptionFlow<V>(this V value)
        {
            return new ExceptionFlow<V>(value);
        }

        public static ExceptionFlow<Y> SideFlow<T, Y>(this ExceptionFlow<T> flow, Func<T, Y> func)
        {
            if (flow.IsStopped)
                return flow.ConvertTo<Y>();

            try
            {
                return new ExceptionFlow<Y>(func(flow.Value));
            }
            catch (Exception e)
            {
                return new ExceptionFlow<Y>(e);
            }
        }
    }

}
