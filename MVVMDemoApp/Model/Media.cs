using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoApp.Model
{
    public abstract class Media
    {
        public string Title { get; }

        public IEnumerable<Genre> Genres { get; }

        protected Media(string title, IEnumerable<Genre> genres)
        {
            Title = title;
            Genres = genres;
        }
    }
}
