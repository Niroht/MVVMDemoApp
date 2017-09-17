using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MVVMDemoApp.ViewModel;
using Microsoft.Practices.Unity;

namespace MVVMDemoApp.Service
{
    public class ViewModelRenderer : IViewModelRenderer
    {
        private readonly ViewModelLocator _locator;
        private readonly IUnityContainer _container;

        public void RenderViewModel<T>() where T : ViewModelBase
        {
            _locator.Main.PrimaryViewModel = _container.Resolve<T>();
        }

        public ViewModelRenderer(ViewModelLocator locator, IUnityContainer container)
        {
            _locator = locator;
            _container = container;
        }
    }
}
