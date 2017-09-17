using Microsoft.Practices.Unity;
using MVVMDemoApp.Providers;
using MVVMDemoApp.Service;
using MVVMDemoApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoApp
{
    public class Bootstrapper
    {
        public static void RunApplication()
        {
            var container = new UnityContainer();
            RegisterInterfaces(container);

            var navigationViewModel = container.Resolve<NavigationViewModel>();
            var locator = container.Resolve<ViewModelLocator>();
            locator.Main.NavigationViewModel = navigationViewModel;
        }

        private static void RegisterInterfaces(UnityContainer container)
        {
            container.RegisterType<IFilteredFilmProvider, FilteredMediaProvider>();
            container.RegisterType<IFilteredTelevisionSeriesProvider, FilteredMediaProvider>();
            container.RegisterType<IFilmProvider, FilmProvider>();
            container.RegisterType<ITelevisionSeriesProvider, TelevisionSeriesProvider>();
            container.RegisterType<IViewModelRenderer, ViewModelRenderer>();
        }
    }
}
