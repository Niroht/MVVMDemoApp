using MVVMDemoApp.Model;
using MVVMDemoApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemoApp.ViewModel
{
    public class TelevisionSeriesLookupViewModel : MediaLookupViewModel<TelevisionSeries, TelevisionSeriesFilterParameters>
    {
        public string Creator
        {
            get
            {
                return FilterParameters.Creator;
            }
            set
            {
                if (FilterParameters.Creator != value)
                {
                    FilterParameters.Creator = value;
                    RaisePropertyChanged(nameof(Creator));
                    FiltersChangedAsync();
                }
            }
        }

        public override string LoadCopy => Properties.Resources.LoadTelevisionSeries;

        public TelevisionSeriesLookupViewModel(IFilteredTelevisionSeriesProvider filteredTelevisionSeriesProvider) : base(filteredTelevisionSeriesProvider)
        {
        }
    }
}
