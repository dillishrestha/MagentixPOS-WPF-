using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using FluentValidation;
using Magentix.Domain.Models.Accounts;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common.ModelBase;

namespace Magentix.Modules.TicketModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class ChangePaymentTypeViewModel : EntityViewModelBaseWithMap<ChangePaymentType, ChangePaymentTypeMap, AbstractMapViewModel<ChangePaymentTypeMap>>
    {
        [ImportingConstructor]
        public ChangePaymentTypeViewModel()
        {
        }

        private IEnumerable<AccountTransactionType> _accountTransactionTypes;
        public IEnumerable<AccountTransactionType> AccountTransactionTypes
        {
            get
            {
                return _accountTransactionTypes ?? (_accountTransactionTypes =
                    Workspace.All<AccountTransactionType>().ToList());
            }
        }

        private IEnumerable<Account> _accounts;
        public IEnumerable<Account> Accounts
        {
            get
            {
                return _accounts ?? (_accounts =
                    AccountTransactionType != null
                    ? Workspace.All<Account>(x => x.AccountTypeId == AccountTransactionType.SourceAccountTypeId).ToList()
                    : new List<Account>());
            }
        }

        public AccountTransactionType AccountTransactionType
        {
            get { return Model.AccountTransactionType; }
            set
            {
                Model.AccountTransactionType = value;
                Account = null;
                _accounts = null;
                RaisePropertyChanged(() => Accounts);
            }
        }

        public Account Account
        {
            get { return Model.Account; }
            set
            {
                Model.Account = value;
                RaisePropertyChanged(() => Account);
            }
        }

        public override Type GetViewType()
        {
            return typeof(ChangePaymentTypeView);
        }

        public override string GetModelTypeString()
        {
            return Resources.ChangePaymentType;
        }

        protected override AbstractValidator<ChangePaymentType> GetValidator()
        {
            return new ChangePaymentTypeValidator();
        }

        protected override void Initialize()
        {
            base.Initialize();
            MapController = new MapController<ChangePaymentTypeMap, AbstractMapViewModel<ChangePaymentTypeMap>>(Model.ChangePaymentTypeMaps, Workspace);
        }
    }

    internal class ChangePaymentTypeValidator : EntityValidator<ChangePaymentType>
    {
        public ChangePaymentTypeValidator()
        {
            RuleFor(x => x.AccountTransactionType).NotNull();
        }
    }
}
