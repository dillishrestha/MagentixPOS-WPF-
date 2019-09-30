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

namespace Magentix.Modules.PaymentModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class DisplayPaymentScreen : ActionType
    {
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public DisplayPaymentScreen(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null && ticket != Ticket.Empty && _ticketService.CanSettleTicket(ticket))
            {
                ticket.PublishEvent(EventTopicNames.MakePayment);
            }
        }

        protected override object GetDefaultData()
        {
            return new object();
        }

        protected override string GetActionName()
        {
            return Resources.DisplayPaymentScreen;
        }

        protected override string GetActionKey()
        {
            return ActionNames.DisplayPaymentScreen;
        }
    }
}
