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
    public class FilmLookupViewModel : ViewModelBase
    {
        private readonly IFilteredFilmProvider _filteredFilmProvider;

        private FilmFilterParameters _filterParameters = new FilmFilterParameters();

        private IEnumerable<Film> _filteredFilms;
        public IEnumerable<Film> FilteredFilms
        {
            get
            {
                return _filteredFilms;
            }
            set
            {
                Set(nameof(FilteredFilms), ref _filteredFilms, value);
            }
        }

        public string Title
        {
            get
            {
                return _filterParameters.Title;
            }
            set
            {
                if (_filterParameters.Title != value)
                {
                    _filterParameters.Title = value;
                    RaisePropertyChanged(nameof(Title));
                    FiltersChanged();
                }
            }
        }

        public string Director
        {
            get
            {
                return _filterParameters.Director;
            }
            set
            {
                if (_filterParameters.Director != value)
                {
                    _filterParameters.Director = value;
                    RaisePropertyChanged(nameof(Director));
                    FiltersChanged();
                }
            }
        }

        public Genre Genre
        {
            get
            {
                return _filterParameters.Genre;
            }
            set
            {
                if (_filterParameters.Genre != value)
                {
                    _filterParameters.Genre = value;
                    RaisePropertyChanged(nameof(Genre));
                    FiltersChanged();
                }
            }
        }

        public IEnumerable<Genre> AvailableGenres => Enum.GetValues(typeof(Genre)).Cast<Genre>();

        public ICommand LoadFilmsCommand => new RelayCommand(LoadFilms);

        public string LoadFilmsCopy => Properties.Resources.LoadFilms;

        public FilmLookupViewModel(IFilteredFilmProvider filteredFilmProvider)
        {
            _filteredFilmProvider = filteredFilmProvider;

            LoadFilms();
            Genre = Genre.Unspecified;
        }

        private void LoadFilms()
        {
            FilteredFilms = _filteredFilmProvider.GetFilms(_filterParameters, true);
        }

        private void FiltersChanged()
        {
            FilteredFilms = _filteredFilmProvider.GetFilms(_filterParameters);
        }
    }
}
