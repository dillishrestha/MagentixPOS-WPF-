using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.Common.Services;

namespace Magentix.Modules.NavigationModule
{
    [Export]
    public class NavigationViewModel : ObservableObject
    {
        public ObservableCollection<ICategoryCommand> CategoryView
        {
            get
            {
                return new ObservableCollection<ICategoryCommand>(
                    PresentationServices.NavigationCommandCategories.OrderBy(x => x.Order));
            }
        }

        public void Refresh()
        {
            RaisePropertyChanged(() => CategoryView);
        }
    }
}
