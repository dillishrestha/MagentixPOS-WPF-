using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services;

namespace Magentix.Modules.WorkperiodModule
{
    [ModuleExport(typeof(WorkPeriodsModule))]
    public class WorkPeriodsModule : VisibleModuleBase
    {
        private readonly IRegionManager _regionManager;
        private readonly WorkPeriodsView _workPeriodsView;
        private readonly IUserService _userService;

        protected override void OnInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(WorkPeriodsView));
        }

        [ImportingConstructor]
        public WorkPeriodsModule(IRegionManager regionManager, WorkPeriodsView workPeriodsView,IUserService userService)
            : base(regionManager, AppScreens.WorkPeriods)
        {
            _regionManager = regionManager;
            _workPeriodsView = workPeriodsView;
            _userService = userService;

            SetNavigationCommand(Resources.DayOperations, Resources.Common, "Images/WorkPeriod.png");
            PermissionRegistry.RegisterPermission(PermissionNames.OpenWorkPeriods, PermissionCategories.Navigation,
                                                  Resources.CanStartEndOfDay);
        }

        public override object GetVisibleView()
        {
            return _workPeriodsView;
        }

        protected override bool CanNavigate(string arg)
        {
            return _userService.IsUserPermittedFor(PermissionNames.OpenWorkPeriods);
        }

        protected override void OnNavigate(string obj)
        {
            base.OnNavigate(obj);
            ((WorkPeriodsViewModel)_workPeriodsView.DataContext).Refresh();
        }
    }
}
