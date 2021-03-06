using GalaSoft.MvvmLight;

namespace MVVMDemoApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private NavigationViewModel _navigationViewModel;
        public NavigationViewModel NavigationViewModel
        {
            get
            {
                return _navigationViewModel;
            }
            set
            {
                Set(nameof(NavigationViewModel), ref _navigationViewModel, value);
            }
        }

        private ViewModelBase _primaryViewModel;
        public ViewModelBase PrimaryViewModel
        {
            get
            {
                return _primaryViewModel;
            }
            set
            {
                Set(nameof(PrimaryViewModel), ref _primaryViewModel, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }
    }
}