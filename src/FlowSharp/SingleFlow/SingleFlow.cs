using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowSharp;

namespace FlowSharp
{
    //public abstract class AbstractFlow<V, T> : ISingleFlow<V, T>
    //    //where T: ISingleFlow<V>
    //{
    //    public V Value { get; }
    //    public bool IsStopped { get; }

    //    public AbstractFlow(V value, bool isStopped = false)
    //    {
    //        this.Value = value;
    //        this.IsStopped = isStopped;
    //    }

    //    //public ISingleFlow<V> Flow(V value)
    //    //{
    //    //    return new SingleFlow<V>(value, false);
    //    //}

    //    //public ISingleFlow<V> Stop(V value)
    //    //{
    //    //    return new SingleFlow<V>(value, true);
    //    //}

    //    public abstract T Flow(V value);
    //    public abstract T Stop(V value);
        

    //    //public ISingleFlow<V> Flow(V value)
    //    //{
    //    //    return new SingleFlow<V>(value, false);
    //    //}

    //    //public ISingleFlow<V> Stop(V value)
    //    //{
    //    //    return new SingleFlow<V>(value, true);
    //    //}

    //    //public static implicit operator V(AbstractFlow<V, T> t)
    //    //{
    //    //    return t.Value;
    //    //}

    //    //public static implicit operator AbstractFlow<V, T>(V v)
    //    //{
    //    //    return new AbstractFlow<V, T>(v, false);
    //    //    //return SingleFlow<V>.Flow(v);
    //    //}
    //}

    public class SingleFlow<V> : ISingleFlow<V, SingleFlow<V>>
    {
        public V Value { get; }
        public bool IsStopped { get; }

        public SingleFlow(V value, bool isStopped = false)
        {
            this.Value = value;
            this.IsStopped = isStopped;
        }

        //public ISingleFlow<V> Flow(V value)
        //{
        //    return new SingleFlow<V>(value, false);
        //}

        //public ISingleFlow<V> Stop(V value)
        //{
        //    return new SingleFlow<V>(value, true);
        //}

        public SingleFlow<V> Flow(V value)
        {
            throw new NotImplementedException();
        }

        public SingleFlow<V> Stop(V value)
        {
            throw new NotImplementedException();
        }

        //public ISingleFlow<V> Flow(V value)
        //{
        //    return new SingleFlow<V>(value, false);
        //}

        //public ISingleFlow<V> Stop(V value)
        //{
        //    return new SingleFlow<V>(value, true);
        //}

        public static implicit operator V(SingleFlow<V> v)
        {
            return v.Value;
        }
        
        public static implicit operator SingleFlow<V>(V v)
        {
            return new SingleFlow<V>(v);
            //return SingleFlow<V>.Flow(v);
        }
    }
}
