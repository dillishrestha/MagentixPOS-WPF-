using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.Common.ModelBase;
using Magentix.Presentation.Common.Services;

namespace Magentix.Modules.ManagementModule
{
    [Export]
    public class ManagementViewModel : ModelListViewModelBase
    {
        public ObservableCollection<DashboardCommandCategory> CategoryView
        {
            get
            {
                var result = new ObservableCollection<DashboardCommandCategory>(
                     PresentationServices.DashboardCommandCategories.OrderBy(x => x.Order));
                return result;
            }
        }

        protected override string GetHeaderInfo()
        {
            return "Dashboard";
        }

        public void Refresh()
        {
            RaisePropertyChanged(() => CategoryView);
        }
    }
}
