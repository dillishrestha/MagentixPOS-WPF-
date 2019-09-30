using System;
using System.ComponentModel.Composition;
using System.Linq;
using Magentix.Domain.Models.Accounts;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common.ModelBase;

namespace Magentix.Modules.AccountModule.Dashboard
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountTypeViewModel : EntityViewModelBase<AccountType>
    {

        [ImportingConstructor]
        public AccountTypeViewModel()
        {
        }

        private readonly string[] _workingRules = new[] { Resources.Default, Resources.Debit, Resources.Credit };
        public string[] WorkingRules
        {
            get { return _workingRules; }
        }
        public string WorkingRule { get { return WorkingRules[Model.WorkingRule]; } set { Model.WorkingRule = WorkingRules.ToList().IndexOf(value); } }

        public string[] FilterTypes { get { return new[] { Resources.All, Resources.Month, Resources.Week, Resources.WorkPeriod }; } }
        public string FilterType { get { return FilterTypes[Model.DefaultFilterType]; } set { Model.DefaultFilterType = FilterTypes.ToList().IndexOf(value); } }
        public string Tags { get { return Model.Tags; } set { Model.Tags = value; } }


        public override string GetModelTypeString()
        {
            return Resources.AccountType;
        }

        public override Type GetViewType()
        {
            return typeof(AccountTypeView);
        }
    }
}
