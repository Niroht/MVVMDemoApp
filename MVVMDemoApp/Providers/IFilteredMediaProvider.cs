using MVVMDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoApp.Providers
{
    public interface IFilteredMediaProvider<T1, T2> where T1 : Media where T2 : MediaFilterParameters
    {
        IEnumerable<T1> GetMedia(T2 filterParameters, bool reload = false);
    }
}
