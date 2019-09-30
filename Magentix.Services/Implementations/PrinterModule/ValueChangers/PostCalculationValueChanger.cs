using System.ComponentModel.Composition;
using Magentix.Domain.Models.Tickets;

namespace Magentix.Services.Implementations.PrinterModule.ValueChangers
{
    [Export]
    public class PostCalculationValueChanger : AbstractValueChanger<Calculation>
    {
        public override string GetTargetTag()
        {
            return "SERVICES";
        }

        protected override string GetModelName(Calculation model)
        {
            return model.Name;
        }
    }
}
