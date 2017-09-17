using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Unity;
using MVVMDemoApp.Service;
using System.Windows.Input;

namespace MVVMDemoApp.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        private readonly IViewModelRenderer _navigationService;

        public ICommand NavigateToFilmsView => new RelayCommand(() => _navigationService.RenderViewModel<FilmLookupViewModel>());

        public ICommand NavigateToTelevisionSeriesView => new RelayCommand(() => _navigationService.RenderViewModel<TelevisionSeriesLookupViewModel>());

        public NavigationViewModel(IViewModelRenderer navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
