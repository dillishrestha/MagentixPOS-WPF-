using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Magentix.Localization.Properties;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services;
using Magentix.Services.Common;

namespace Magentix.Modules.TicketModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class TagOrder : OrderTagOperation
    {
        [ImportingConstructor]
        public TagOrder(ICacheService cacheService, ITicketService ticketService)
            : base(cacheService, ticketService)
        {
        }

        protected override string GetActionName()
        {
            return Resources.TagOrder;
        }

        protected override string GetActionKey()
        {
            return ActionNames.TagOrder;
        }
    }
}
