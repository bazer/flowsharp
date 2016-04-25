using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowSharp
{
    public interface IFlow
    {
        bool IsStopped { get; }
    }
}
