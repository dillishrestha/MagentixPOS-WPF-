using System.ComponentModel.Composition;
using Magentix.Domain.Models.Accounts;

namespace Magentix.Services.Implementations.PrinterModule.ValueChangers
{
    [Export]
    public class AccountTransactionValueChanger : AbstractValueChanger<AccountTransaction>
    {
        public override string GetTargetTag()
        {
            return "TRANSACTIONS";
        }

        protected override string GetModelName(AccountTransaction model)
        {
            return model.Name;
        }
    }
}