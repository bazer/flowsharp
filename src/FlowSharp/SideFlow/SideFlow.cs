using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public interface ISideFlow<V, S> : IFlow
    {
        V Value { get; }
        IEnumerable<S> SideValue { get; }
        ISideFlow<Y, S> Flow<Y>(Y value);
        ISideFlow<Y, S> Stop<Y>(S value);
        //ISideFlow<T, S> Convert<T>();
    }

    public class SideFlow<V, S> : ISideFlow<V, S>
    {
        public V Value { get; }
        public IEnumerable<S> SideValue { get; }
        public bool IsStopped { get; }


        public SideFlow(V value)
        {
            this.Value = value;
            this.IsStopped = false;
        }

        public SideFlow(ICollection<S> sideValue, bool isStopped = true)
        {
            this.SideValue = sideValue;
            this.IsStopped = isStopped;
        }

        //public Y Flow<Y>(Y value)
        //     where Y : ISideFlow<Y, S, Y>
        //{
        //    //return new SideFlow<Y, S>(value);
        //}

        //public SideFlow<V, S> Stop(S sideValue)
        //{
        //    return new SideFlow<V, S>(sideValue);
        //}

        //public static SideFlow<V, S> Continue(S sideValue)
        //{
        //    return new SideFlow<V, S>(sideValue);
        //}

        //public ISideFlow<T, S> Convert<T>()
        //{
        //    throw new NotImplementedException();
        //}

        //public Y Flow<Y>(Y value) where Y : ISideFlow<V, S, Y>
        //{
        //    return (Y)new SideFlow<Y, S>(value);
        //}

        //public Y Stop<Y>(S value) where Y : ISideFlow<V, S, Y>
        //{
        //    throw new NotImplementedException();
        //}

        ISideFlow<Y, S> ISideFlow<V, S>.Flow<Y>(Y value)
        {
            throw new NotImplementedException();
        }

        ISideFlow<Y, S> ISideFlow<V, S>.Stop<Y>(S value)
        {
            throw new NotImplementedException();
        }
    }

}
