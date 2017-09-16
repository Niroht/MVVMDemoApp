using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemoApp.Model;

namespace MVVMDemoApp.Providers
{
    public class FilteredFilmProvider : IFilteredFilmProvider
    {
        private readonly IFilmProvider _filmProvider;

        private List<Film> filmsCache;

        public FilteredFilmProvider(IFilmProvider filmProvider)
        {
            _filmProvider = filmProvider;
        }

        public IEnumerable<Film> GetFilms(FilmFilterParameters filterParameters, bool reload = false)
        {
            if (reload || filmsCache == null)
            {
                filmsCache = _filmProvider.GetFilms()?.ToList();
            }

            if (filmsCache == null || !filmsCache.Any())
            {
                return Enumerable.Empty<Film>();
            }

            var results = filmsCache.Select(x => x).ToList();

            if (!string.IsNullOrEmpty(filterParameters.Title))
            {
                results.RemoveAll(x => !x.Title.ToLowerInvariant().Contains(filterParameters.Title.ToLowerInvariant()));
            }

            if (!string.IsNullOrEmpty(filterParameters.Director))
            {
                results.RemoveAll(x => NoFilmDirectorsMatchFilter(filterParameters, x));
            }

            if (filterParameters.Genre != Genre.Unspecified)
            {
                results.RemoveAll(x => !x.Genres.Contains(filterParameters.Genre));
            }

            return results;
        }

        private static bool NoFilmDirectorsMatchFilter(FilmFilterParameters filterParameters, Film film)
        {
            return !film.Directors.Any(director => director.ToLowerInvariant().Contains(filterParameters.Director.ToLowerInvariant()));
        }
    }
}
