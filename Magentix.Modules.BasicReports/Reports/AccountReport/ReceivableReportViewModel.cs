using System.Windows.Documents;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services;
using Magentix.Services;

namespace Magentix.Modules.BasicReports.Reports.AccountReport
{
    public class ReceivableReportViewModel : AccountReportViewModelBase
    {
        public ReceivableReportViewModel(IUserService userService, IApplicationState applicationState, ILogService logService, ISettingService settingService)
            : base(userService, applicationState, logService, settingService)
        {
        }

        protected override FlowDocument GetReport()
        {
            return CreateReport(Resources.AccountsReceivable, true, false);
        }

        protected override string GetHeader()
        {
            return Resources.AccountsReceivable;
        }
    }
}
