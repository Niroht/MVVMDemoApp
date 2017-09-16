using Microsoft.Practices.Unity;
using MVVMDemoApp.Providers;
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

            var filmLookupViewModel = container.Resolve<FilmLookupViewModel>();

            var locator = container.Resolve<ViewModelLocator>();
            locator.Main.PrimaryViewModel = filmLookupViewModel;
            locator.Main.Test = "Loaded";
        }

        private static void RegisterInterfaces(UnityContainer container)
        {
            container.RegisterType<IFilteredFilmProvider, FilteredFilmProvider>();
            container.RegisterType<IFilmProvider, FilmProvider>();
        }
    }
}
