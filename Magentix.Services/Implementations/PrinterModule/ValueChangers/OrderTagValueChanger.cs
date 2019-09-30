using System.ComponentModel.Composition;
using Magentix.Domain.Models.Tickets;

namespace Magentix.Services.Implementations.PrinterModule.ValueChangers
{
    [Export]
    public class OrderTagValueChanger : AbstractValueChanger<OrderTagValue>
    {
        protected override bool FilterMatch(OrderTagValue model, string key)
        {
            return model.TagName == key;
        }

        public override string GetTargetTag()
        {
            return "ORDER TAGS";
        }

        protected override string GetModelName(OrderTagValue model)
        {
            return model.TagValue;
        }
    }
}
