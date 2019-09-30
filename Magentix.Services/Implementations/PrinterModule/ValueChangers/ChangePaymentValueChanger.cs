using System.ComponentModel.Composition;
using Magentix.Domain.Models.Tickets;

namespace Magentix.Services.Implementations.PrinterModule.ValueChangers
{
    [Export]
    public class ChangePaymentValueChanger : AbstractValueChanger<ChangePayment>
    {
        public override string GetTargetTag()
        {
            return "CHANGES";
        }

        protected override string GetModelName(ChangePayment model)
        {
            return model.Name;
        }
    }
}
