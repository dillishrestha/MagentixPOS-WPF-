using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services.Common;

namespace Magentix.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class CreateTicket : ActionType
    {
        private readonly IApplicationState _applicationState;
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public CreateTicket(IApplicationState applicationState, ITicketService ticketService)
        {
            _applicationState = applicationState;
            _ticketService = ticketService;
        }

        public override void Process(ActionData actionData)
        {
            var ticketId = actionData.GetDataValueAsInt("TicketId");
            if (ticketId > 0 && !_applicationState.IsLocked)
            {
                var ticket = _ticketService.OpenTicket(ticketId);
                ticket.PublishEvent(EventTopicNames.SetSelectedTicket);
            }
            EventServiceFactory.EventService.PublishEvent(EventTopicNames.CreateTicket);
        }

        protected override object GetDefaultData()
        {
            return new object();
        }

        protected override string GetActionName()
        {
            return string.Format(Resources.Create_f, Resources.Ticket);
        }

        protected override string GetActionKey()
        {
            return ActionNames.CreateTicket;
        }
    }
}
