using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoApp.Model
{
    public class TelevisionSeries : Media
    {
        public IEnumerable<string> Creators { get; }

        public TelevisionSeries(string title, IEnumerable<string> creators, IEnumerable<Genre> genres) : base(title, genres)
        {
            Creators = creators;
        }
    }
}
