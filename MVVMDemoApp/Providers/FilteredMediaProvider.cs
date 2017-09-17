using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemoApp.Model;

namespace MVVMDemoApp.Providers
{
    public class FilteredMediaProvider : IFilteredFilmProvider, IFilteredTelevisionSeriesProvider
    {
        private readonly ITelevisionSeriesProvider _televisionSeriesProvider;
        private readonly IFilmProvider _filmProvider;

        private List<Film> _filmsCache;
        private List<TelevisionSeries> _televisionSeriesCache;

        public FilteredMediaProvider(IFilmProvider filmProvider, ITelevisionSeriesProvider televisionSeriesProvider)
        {
            _filmProvider = filmProvider;
            _televisionSeriesProvider = televisionSeriesProvider;
        }

        public IEnumerable<TelevisionSeries> GetMedia(TelevisionSeriesFilterParameters filterParameters, bool reload = false)
        {
            if (reload || _televisionSeriesCache == null)
            {
                _televisionSeriesCache = _televisionSeriesProvider.GetTelevisionSeries()?.ToList();
            }

            if (_televisionSeriesCache == null || !_televisionSeriesCache.Any())
            {
                return Enumerable.Empty<TelevisionSeries>();
            }

            var results = _televisionSeriesCache.Select(x => x).ToList();

            FilterUniversalMediaAttributes(results, filterParameters);

            if (!string.IsNullOrEmpty(filterParameters.Creator))
            {
                results.RemoveAll(x => NoCreatorsMatchFilter(filterParameters, x));
            }

            return results;
        }

        public IEnumerable<Film> GetMedia(FilmFilterParameters filterParameters, bool reload = false)
        {
            if (reload || _filmsCache == null)
            {
                _filmsCache = _filmProvider.GetFilms()?.ToList();
            }

            if (_filmsCache == null || !_filmsCache.Any())
            {
                return Enumerable.Empty<Film>();
            }

            var results = _filmsCache.Select(x => x).ToList();

            FilterUniversalMediaAttributes(results, filterParameters);

            if (!string.IsNullOrEmpty(filterParameters.Director))
            {
                results.RemoveAll(x => NoFilmDirectorsMatchFilter(filterParameters, x));
            }

            return results;
        }

        private static void FilterUniversalMediaAttributes<T>(List<T> media, MediaFilterParameters filterParameters) where T : Media
        {
            if (!string.IsNullOrEmpty(filterParameters.Title))
            {
                media.RemoveAll(x => !x.Title.ToLowerInvariant().Contains(filterParameters.Title.ToLowerInvariant()));
            }

            if (filterParameters.Genre != Genre.Unspecified)
            {
                media.RemoveAll(x => !x.Genres.Contains(filterParameters.Genre));
            }
        }

        private static bool NoFilmDirectorsMatchFilter(FilmFilterParameters filterParameters, Film film)
        {
            return !film.Directors.Any(director => director.ToLowerInvariant().Contains(filterParameters.Director.ToLowerInvariant()));
        }

        private static bool NoCreatorsMatchFilter(TelevisionSeriesFilterParameters filterParameters, TelevisionSeries televisionSeries)
        {
            return !televisionSeries.Creators.Any(director => director.ToLowerInvariant().Contains(filterParameters.Creator.ToLowerInvariant()));
        }
    }
}
