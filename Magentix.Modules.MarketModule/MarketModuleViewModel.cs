using System.Collections.Generic;
using System.ComponentModel.Composition;
using Magentix.Domain.Models.Menus;
using Magentix.Presentation.Common;
using Magentix.Services;

namespace Magentix.Modules.MarketModule
{
    [Export]
    public class MarketModuleViewModel : ObservableObject
    {
        private string _activeUrl;
        public string ActiveUrl
        {
            get { return _activeUrl; }
            set { _activeUrl = value; RaisePropertyChanged(() => ActiveUrl); }
        }
    }
}
