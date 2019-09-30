using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services;

namespace Magentix.Modules.ManagementModule
{
    [ModuleExport(typeof(ManagementModule))]
    public class ManagementModule : VisibleModuleBase
    {
        private readonly IRegionManager _regionManager;
        private readonly ManagementView _dashboardView;
        private readonly IUserService _userService;

        [ImportingConstructor]
        public ManagementModule(IRegionManager regionManager, ManagementView dashboardView, IUserService userService)
            : base(regionManager, AppScreens.Management)
        {
            _regionManager = regionManager;
            _dashboardView = dashboardView;
            _userService = userService;
            SetNavigationCommand(Resources.Management, Resources.Common, "Images/Manage.png", 70);
            PermissionRegistry.RegisterPermission(PermissionNames.OpenDashboard, PermissionCategories.Navigation, Resources.CanOpenDashboard);
        }

        protected override bool CanNavigate(string arg)
        {
            return _userService.IsUserPermittedFor(PermissionNames.OpenDashboard);
        }

        protected override void OnNavigate(string obj)
        {
            base.OnNavigate(obj);
            ((ManagementViewModel)_dashboardView.DataContext).Refresh();
        }

        public override object GetVisibleView()
        {
            return _dashboardView;
        }

        protected override void OnPreInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(ManagementView));
            _regionManager.RegisterViewWithRegion(RegionNames.UserRegion, typeof(KeyboardButtonView));
        }
    }
}
