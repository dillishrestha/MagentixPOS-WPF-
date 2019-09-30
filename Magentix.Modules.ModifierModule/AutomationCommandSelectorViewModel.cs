using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.Practices.Prism.Commands;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services;
using Magentix.Services.Common;

namespace Magentix.Modules.ModifierModule
{
    [Export]
    public class AutomationCommandSelectorViewModel : ObservableObject
    {
        private readonly IApplicationState _applicationState;
        private readonly IExpressionService _expressionService;

        public DelegateCommand<AutomationCommandData> SelectAutomationCommand { get; set; }
        public ICaptionCommand CloseCommand { get; set; }

        [ImportingConstructor]
        public AutomationCommandSelectorViewModel(IApplicationState applicationState, IExpressionService expressionService)
        {
            _applicationState = applicationState;
            _expressionService = expressionService;
            SelectAutomationCommand = new DelegateCommand<AutomationCommandData>(OnSelectAutomationCommand, CanSelectAutomationCommand);
            CloseCommand = new CaptionCommand<string>(Resources.Close, OnCloseCommandExecuted);
        }

        private Ticket _selectedTicket;
        public Ticket SelectedTicket
        {
            get { return _selectedTicket; }
            set
            {
                _selectedTicket = value;
                UpdateAutomationCommands();
            }
        }

        public IEnumerable<AutomationCommandData> AutomationCommands { get; set; }

        public int ColumnCount { get { return AutomationCommands.Count() % 7 == 0 ? AutomationCommands.Count() / 7 : (AutomationCommands.Count() / 7) + 1; } }

        private bool CanSelectAutomationCommand(AutomationCommandData arg)
        {
            return arg.CanExecute(SelectedTicket) && _expressionService.EvalCommand(FunctionNames.CanExecuteAutomationCommand, arg.AutomationCommand, new { Ticket = SelectedTicket }, true);
        }

        private void OnSelectAutomationCommand(AutomationCommandData obj)
        {
            obj.PublishEvent(EventTopicNames.HandlerRequested, true);
        }

        private void OnCloseCommandExecuted(string obj)
        {
            EventServiceFactory.EventService.PublishEvent(EventTopicNames.ActivatePosView);
        }

        private void UpdateAutomationCommands()
        {
            AutomationCommands = _applicationState.GetAutomationCommands().Where(x => x.DisplayOnCommandSelector && x.CanDisplay(_selectedTicket));
            RaisePropertyChanged(() => AutomationCommands);
            RaisePropertyChanged(() => ColumnCount);
        }
    }
}
