using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public static class SingleFlowCasting
    {
        public static SingleFlow<O> Flow<O>(this O value)
        {
            return new SingleFlow<O>(value);
        }

        public static SingleFlow<O> Stop<O>(this O value)
        {
            return new SingleFlow<O>(value, true);
        }

        //public static ISingleFlow<O, ISingleFlow<O>> Flow<O>(this O value)
        //{
        //    return new SingleFlow<O>(value);
        //}

        //public static SingleFlow<O> Stop<O>(this O value)
        //{
        //    return new SingleFlow<O>(value, true);
        //}
    }
}
