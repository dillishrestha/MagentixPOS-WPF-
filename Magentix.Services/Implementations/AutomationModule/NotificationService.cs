using System;
using System.ComponentModel.Composition;
using Magentix.Services.Common;

namespace Magentix.Services.Implementations.AutomationModule
{
    [Export(typeof(INotificationService))]
    class NotificationService : INotificationService
    {
        private readonly RuleExecutor _ruleExecutor;

        [ImportingConstructor]
        public NotificationService(RuleExecutor ruleExecutor)
        {
            _ruleExecutor = ruleExecutor;
        }

        public void NotifyEvent(string eventName, object dataParameter, int terminalId, int departmentId, int userRoleId, int ticketTypeId,
            Action<ActionData> dataAction)
        {
            _ruleExecutor.SelectFor(eventName)
                     .WithTerminalId(terminalId)
                     .WithDepartmentId(departmentId)
                     .WithUserRoleId(userRoleId)
                     .WithTicketTypeId(ticketTypeId)
                     .ExecuteWith(dataParameter, dataAction);
        }
    }
}
