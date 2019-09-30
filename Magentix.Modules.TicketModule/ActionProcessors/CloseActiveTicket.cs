using System.ComponentModel.Composition;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common.Services;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services.Common;

namespace Magentix.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class CloseActiveTicket : ActionType
    {
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public CloseActiveTicket(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null && ticket != Ticket.Empty && CanCloseTicket(ticket))
            {
                EventServiceFactory.EventService.PublishEvent(EventTopicNames.CloseTicketRequested, true);
            }
        }

        private bool CanCloseTicket(Ticket ticket)
        {
            if (!_ticketService.CanCloseTicket(ticket))
            {
                foreach (var order in ticket.Orders)
                {
                    var ot = _ticketService.GetMandantoryOrderTagGroup(order);
                    if (ot != null)
                    {
                        var suffix = Resources.PluralCurrencySuffix ?? ".";
                        InteractionService.UserIntraction.GiveFeedback(
                            string.Format("Select at least {0} {1} tag{2} for {3}",
                                          ot.MinSelectedItems, ot.Name,
                                          ot.MinSelectedItems == 1 ? "" : suffix.Replace(".", ""),
                                          order.MenuItemName));
                        return false;
                    }
                }
            }
            return true;
        }

        protected override object GetDefaultData()
        {
            return new object();
        }

        protected override string GetActionName()
        {
            return Resources.CloseTicket;
        }

        protected override string GetActionKey()
        {
            return ActionNames.CloseActiveTicket;
        }
    }
}
