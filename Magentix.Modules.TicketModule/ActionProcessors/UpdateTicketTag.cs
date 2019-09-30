using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services;
using Magentix.Services.Common;

namespace Magentix.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class UpdateTicketTag : ActionType
    {
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public UpdateTicketTag(ITicketService ticketService, ICacheService cacheService)
        {
            _ticketService = ticketService;
        }

        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null)
            {
                var tagName = actionData.GetAsString("TagName");
                var tagValue = actionData.GetAsString("TagValue");
                _ticketService.UpdateTag(ticket, tagName, tagValue);
            }
        }

        protected override object GetDefaultData()
        {
            return new { TagName = "", TagValue = "" };
        }

        protected override string GetActionName()
        {
            return Resources.UpdateTicketTag;
        }

        protected override string GetActionKey()
        {
            return ActionNames.UpdateTicketTag;
        }
    }
}
