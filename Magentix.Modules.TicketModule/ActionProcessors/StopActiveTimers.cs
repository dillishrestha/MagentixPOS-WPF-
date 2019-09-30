using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services.Common;
using Magentix.Services.Common;

namespace Magentix.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class StopActiveTimers : ActionType
    {
        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null)
            {
                ticket.StopActiveTimers();
            }
        }

        protected override object GetDefaultData()
        {
            return new object();
        }

        protected override string GetActionName()
        {
            return Resources.StopProductTimers;
        }

        protected override string GetActionKey()
        {
            return ActionNames.StopActiveTimers;
        }
    }
}
