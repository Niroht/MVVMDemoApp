using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemoApp.Model;

namespace MVVMDemoApp.Providers
{
    public class FilmProvider : IFilmProvider
    {
        private static readonly IEnumerable<Film> _films = new[]
        {
            new Film("Beauty and the Beast", new[] { "Bill Condon" }, new[] { Genre.Romance, Genre.Musical, Genre.Fantasy}),
            new Film("The Fate of the Furious", new[] { "F. Gary Gray" }, new[] { Genre.Action }),
            new Film("Despicable Me 3", new[] { "Pierre Coffin", "Kyle Balda" }, new [] { Genre.Comedy }),
            new Film("Guardians of the Galaxy Vol. 2", new[] { "James Gunn" }, new[] { Genre.Action}),
            new Film("Spider-Man: Homecoming", new[]{ "Jon Watts" }, new[] { Genre.Action }),
            new Film("Wonder Woman", new[]{ "Patty Jenkins" }, new[]{ Genre.Action }),
            new Film("Pirates of the Caribbean: Dead Men Tell No Tales", new [] { "Joachim Rønning", "Espen Sandberg" }, new[] { Genre.Fantasy, Genre.Action}),
            new Film("Logan", new []{ "James Mangold"}, new[] { Genre.Action, Genre.Drama }),
            new Film("Transformers: The Last Knight", new[] {"Michael Bay"}, new[] { Genre.Action, Genre.ScienceFiction })
        };

        public IEnumerable<Film> GetFilms()
        {
            return _films;
        }
    }
}
