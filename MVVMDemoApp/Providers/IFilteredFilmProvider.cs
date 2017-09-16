using MVVMDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoApp.Providers
{
    public interface IFilteredFilmProvider
    {
        IEnumerable<Film> GetFilms(FilmFilterParameters filterParameters, bool reload = false);
    }
}
