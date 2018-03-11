using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NP.Interface
{
    public interface IOutputPayment
    {
        bool Config(string config);
        bool Save(string data);
    }
}
