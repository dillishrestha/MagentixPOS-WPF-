using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;

namespace Magentix.Modules.MarketModule
{
    [ModuleExport(typeof(MarketModule))]
    public class MarketModule : VisibleModuleBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IUserService _userService;
        private readonly MarketModuleView _marketModuleView;
        private readonly MarketModuleViewModel _marketModuleViewModel;

        [ImportingConstructor]
        public MarketModule(IRegionManager regionManager, IUserService userService, MarketModuleView marketModuleView, MarketModuleViewModel marketModuleViewModel)
            : base(regionManager, AppScreens.MarketView)
        {
            _regionManager = regionManager;
            _userService = userService;
            _marketModuleView = marketModuleView;
            _marketModuleViewModel = marketModuleViewModel;

            SetNavigationCommand(Resources.MagentixMarket, Resources.Common, "Images/Market.png", 50);
            PermissionRegistry.RegisterPermission(PermissionNames.OpenMarket, PermissionCategories.Navigation, string.Format(Resources.CanNavigate_f, Resources.Market));
        }

        protected override void OnInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(MarketModuleView));
        }

        protected override bool CanNavigate(string arg)
        {
            return false;
            //return _userService.IsUserPermittedFor(PermissionNames.OpenMarket);
        }

        protected override void OnNavigate(string obj)
        {
            base.OnNavigate(obj);
            _marketModuleViewModel.ActiveUrl = "about:blank";
            _marketModuleViewModel.ActiveUrl = "http://www.Magentixmarket.com/";
        }

        public override object GetVisibleView()
        {
            return _marketModuleView;
        }
    }
}
