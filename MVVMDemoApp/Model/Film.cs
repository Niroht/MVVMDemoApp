using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoApp.Model
{
    public class Film : Media
    {
        public IEnumerable<string> Directors { get; }

        public Film(string title, IEnumerable<string> directors, IEnumerable<Genre> genres) : base(title, genres)
        {
            Directors = directors;
        }
    }
}
