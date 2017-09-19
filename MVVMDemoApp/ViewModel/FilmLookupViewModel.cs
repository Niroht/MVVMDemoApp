using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMDemoApp.Model;
using MVVMDemoApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace MVVMDemoApp.ViewModel
{
    public class FilmLookupViewModel : MediaLookupViewModel<Film, FilmFilterParameters>
    {
        private readonly IFilteredFilmProvider _filteredFilmProvider;

        public string Director
        {
            get
            {
                return FilterParameters.Director;
            }
            set
            {
                if (FilterParameters.Director != value)
                {
                    FilterParameters.Director = value;
                    RaisePropertyChanged(nameof(Director));
                    FiltersChangedAsync();
                }
            }
        }

        public override string LoadCopy => Properties.Resources.LoadFilms;

        public FilmLookupViewModel(IFilteredFilmProvider filteredFilmProvider) : base(filteredFilmProvider)
        {
        }
    }
}
