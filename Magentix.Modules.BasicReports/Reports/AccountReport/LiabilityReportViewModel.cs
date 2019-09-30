using System.Windows.Documents;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services;
using Magentix.Services;

namespace Magentix.Modules.BasicReports.Reports.AccountReport
{
    class LiabilityReportViewModel : AccountReportViewModelBase
    {
        public LiabilityReportViewModel(IUserService userService, IApplicationState applicationState, ILogService logService, ISettingService settingService)
            : base(userService, applicationState, logService, settingService)
        {
        }

        protected override FlowDocument GetReport()
        {
            return CreateReport(Resources.AccountsLiability, false, false);
        }

        protected override string GetHeader()
        {
            return Resources.AccountsLiability;
        }
    }
}
