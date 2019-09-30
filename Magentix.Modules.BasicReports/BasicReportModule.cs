using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Regions;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services;

namespace Magentix.Modules.BasicReports
{
    [ModuleExport(typeof(BasicReportModule))]
    public class BasicReportModule : VisibleModuleBase
    {
        private readonly IRegionManager _regionManager;
        private readonly BasicReportView _basicReportView;
        private readonly IUserService _userService;

        [ImportingConstructor]
        public BasicReportModule(IRegionManager regionManager, BasicReportView basicReportView,
            IWorkPeriodService workPeriodService, IPrinterService printerService, ICacheService cacheService,
            IInventoryService inventoryService, IUserService userService, IAutomationService automationService,
            IApplicationState applicationState, ILogService logService, ISettingService settingService)
            : base(regionManager, AppScreens.ReportView)
        {
            ReportContext.PrinterService = printerService;
            ReportContext.WorkPeriodService = workPeriodService;
            ReportContext.InventoryService = inventoryService;
            ReportContext.UserService = userService;
            ReportContext.ApplicationState = applicationState;
            ReportContext.CacheService = cacheService;
            ReportContext.LogService = logService;
            ReportContext.SettingService = settingService;

            _userService = userService;

            _regionManager = regionManager;
            _basicReportView = basicReportView;
            SetNavigationCommand(Resources.Reports, Resources.Common, "Images/Reports.png", 60);

            PermissionRegistry.RegisterPermission(PermissionNames.OpenReports, PermissionCategories.Navigation, Resources.CanDisplayReports);
            PermissionRegistry.RegisterPermission(PermissionNames.ChangeReportDate, PermissionCategories.Report, Resources.CanChangeReportFilter);

            //todo refactor
            automationService.RegisterParameterSource("ReportName", () => ReportContext.Reports.Select(x => x.Header));

        }

        public override object GetVisibleView()
        {
            return _basicReportView;
        }

        protected override bool CanNavigate(string arg)
        {
            return false;
            return (_userService.IsUserPermittedFor(PermissionNames.OpenReports)
                && ReportContext.ApplicationState.CurrentWorkPeriod != null);
        }

        protected override void OnNavigate(string obj)
        {
            base.OnNavigate(obj);
            ReportContext.ResetCache();
            ReportContext.CurrentWorkPeriod = ReportContext.ApplicationState.CurrentWorkPeriod;
        }

        protected override void OnInitialization()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(BasicReportView));
        }
    }
}
