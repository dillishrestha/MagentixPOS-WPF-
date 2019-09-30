using System.ComponentModel;
using Magentix.Domain.Models.Entities;
using Magentix.Domain.Models.Tickets;
using Magentix.Infrastructure.Helpers;
using Magentix.Persistance;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.Common.Widgets;
using Magentix.Presentation.Services;
using Magentix.Services.Common;

namespace Magentix.Modules.AutomationModule.WidgetCreators
{
    class AutomationButtonWidgetViewModel : WidgetViewModel
    {
        private readonly IApplicationState _applicationState;
        private readonly IAutomationDao _automationDao;

        [Browsable(false)]
        public CaptionCommand<AutomationButtonWidgetViewModel> ItemClickedCommand { get; set; }

        public AutomationButtonWidgetViewModel(Widget widget, IApplicationState applicationState, IAutomationDao automationDao)
            : base(widget, applicationState)
        {
            _applicationState = applicationState;
            _automationDao = automationDao;
            ItemClickedCommand = new CaptionCommand<AutomationButtonWidgetViewModel>("", OnItemClicked);
        }

        private void OnItemClicked(AutomationButtonWidgetViewModel obj)
        {
            _applicationState.NotifyEvent(RuleEventNames.AutomationCommandExecuted,
                new
                    {
                        Ticket = Ticket.Empty,
                        AutomationCommandName = obj.Settings.CommandName,
                        CommandValue = obj.Settings.Value
                    });
        }

        protected override object CreateSettingsObject()
        {
            return JsonHelper.Deserialize<AutomationButtonWidgetSettings>(_model.Properties);
        }

        public override void Refresh()
        {
            //
        }

        [Browsable(false)]
        public AutomationButtonWidgetSettings Settings { get { return SettingsObject as AutomationButtonWidgetSettings; } }


        protected override void BeforeEditSettings()
        {
            Settings.CommandNameValue.UpdateValues(_automationDao.GetAutomationCommandNames());
        }
    }
}
