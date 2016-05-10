using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public class StringFlow<T> : ISideFlow<T, string>
    {
        public bool IsStopped
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string SideValue
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public T Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ISideFlow<Y, string> Flow<Y>(Y value)
        {
            throw new NotImplementedException();
        }

        public ISideFlow<Y, string> Stop<Y>(string value)
        {
            throw new NotImplementedException();
        }
    }
}
