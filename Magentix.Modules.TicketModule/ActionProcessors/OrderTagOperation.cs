using System.Linq;
using Magentix.Domain.Models.Tickets;
using Magentix.Presentation.Services;
using Magentix.Presentation.Services.Common;
using Magentix.Services;
using Magentix.Services.Common;

namespace Magentix.Modules.TicketModule.ActionProcessors
{
    abstract class OrderTagOperation : ActionType
    {
        private readonly ICacheService _cacheService;
        private readonly ITicketService _ticketService;

        protected OrderTagOperation(ICacheService cacheService, ITicketService ticketService)
        {
            _cacheService = cacheService;
            _ticketService = ticketService;
        }

        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            var orders = Helper.GetOrders(actionData, ticket);
            if (orders.Any())
            {
                var tagName = actionData.GetAsString("OrderTagName");
                var orderTag = _cacheService.GetOrderTagGroupByName(tagName);

                if (orderTag != null)
                {
                    var tagValue = actionData.GetAsString("OrderTagValue");
                    var oldTagValue = actionData.GetAsString("OldOrderTagValue");
                    var tagNote = actionData.GetAsString("OrderTagNote");
                    var orderTagValue = orderTag.OrderTags.SingleOrDefault(y => y.Name == tagValue);

                    if (orderTagValue != null)
                    {
                        if (!string.IsNullOrEmpty(actionData.GetAsString("OrderTagPrice")))
                        {
                            var price = actionData.GetAsDecimal("OrderTagPrice");
                            orderTagValue.Price = price;
                        }

                        if (!string.IsNullOrEmpty(oldTagValue))
                            orders = orders.Where(o => o.OrderTagExists(y => y.OrderTagGroupId == orderTag.Id && y.TagValue == oldTagValue)).ToList();
                        if (actionData.Action.ActionType == ActionNames.TagOrder)
                            _ticketService.TagOrders(ticket, orders, orderTag, orderTagValue, tagNote);
                        if (actionData.Action.ActionType == ActionNames.UntagOrder)
                            _ticketService.UntagOrders(ticket, orders, orderTag, orderTagValue);
                    }
                }
            }
        }

        protected override object GetDefaultData()
        {
            return
                new
                    {
                        OrderTagName = "",
                        OldOrderTagValue = "",
                        OrderTagValue = "",
                        OrderTagNote = "",
                        OrderTagPrice = ""
                    };
        }
    }
}
