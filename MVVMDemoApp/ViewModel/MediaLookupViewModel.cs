using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMDemoApp.Model;
using MVVMDemoApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MVVMDemoApp.ViewModel
{
    public abstract class MediaLookupViewModel<T1, T2> : ViewModelBase where T1: Media where T2 : MediaFilterParameters, new()
    {
        private readonly IFilteredMediaProvider<T1, T2> _filteredMediaProvider;

        protected T2 FilterParameters { get; } = new T2();

        private IEnumerable<Media> _filteredMedia;
        public IEnumerable<Media> FilteredMedia
        {
            get
            {
                return _filteredMedia;
            }
            set
            {
                Set(nameof(FilteredMedia), ref _filteredMedia, value);
            }
        }

        public Genre Genre
        {
            get
            {
                return FilterParameters.Genre;
            }
            set
            {
                if (FilterParameters.Genre != value)
                {
                    FilterParameters.Genre = value;
                    RaisePropertyChanged(nameof(Genre));
                    FiltersChanged();
                }
            }
        }

        public string Title
        {
            get
            {
                return FilterParameters.Title;
            }
            set
            {
                if (FilterParameters.Title != value)
                {
                    FilterParameters.Title = value;
                    RaisePropertyChanged(nameof(Title));
                    FiltersChanged();
                }
            }
        }

        public IEnumerable<Genre> AvailableGenres => Enum.GetValues(typeof(Genre)).Cast<Genre>();

        public ICommand LoadMediaCommand => new RelayCommand(LoadMedia);

        public virtual string LoadCopy => Properties.Resources.Load;

        protected MediaLookupViewModel(IFilteredMediaProvider<T1, T2> filteredMediaProvider)
        {
            _filteredMediaProvider = filteredMediaProvider;

            Genre = Genre.Unspecified;
            LoadMedia();
        }

        protected void LoadMedia()
        {
            FilteredMedia = _filteredMediaProvider?.GetMedia(FilterParameters, true);
        }

        protected void FiltersChanged()
        {
            FilteredMedia = _filteredMediaProvider?.GetMedia(FilterParameters);
        }
    }
}
