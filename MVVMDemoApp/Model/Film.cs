using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoApp.Model
{
    public class Film
    {
        public string Title { get; }

        public IEnumerable<string> Directors { get; }

        public IEnumerable<Genre> Genres { get; }

        public Film(string title, IEnumerable<string> directors, IEnumerable<Genre> genres)
        {
            Title = title;
            Directors = directors;
            Genres = genres;
        }
    }
}
