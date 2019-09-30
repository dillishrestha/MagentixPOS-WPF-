using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services.Common;

namespace Magentix.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class UpdateTicketState : ActionType
    {
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public UpdateTicketState(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null)
            {
                var stateName = actionData.GetAsString("StateName");
                var currentState = actionData.GetAsString("CurrentState");
                var state = actionData.GetAsString("State");
                var stateValue = actionData.GetAsString("StateValue");
                var quantity = actionData.GetAsString("QuantityExp");
                _ticketService.UpdateTicketState(ticket, stateName, currentState, state, stateValue, quantity);
            }
        }

        protected override object GetDefaultData()
        {
            return new { StateName = "", CurrentState = "", State = "", StateValue = "", QuantityExp = "" };
        }

        protected override string GetActionName()
        {
            return Resources.UpdateTicketState;
        }

        protected override string GetActionKey()
        {
            return ActionNames.UpdateTicketState;
        }
    }
}
