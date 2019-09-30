using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Magentix.Domain.Models.Settings;
using Magentix.Domain.Models.Tickets;
using Magentix.Localization.Properties;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.ViewModels;

namespace Magentix.Modules.PaymentModule
{
    public class PaymentButtonGroupViewModel : ObservableObject
    {
        public PaymentButtonGroupViewModel()
        {
            _paymentButtons = new ObservableCollection<CommandButtonViewModel<PaymentType>>();
        }

        private readonly ObservableCollection<CommandButtonViewModel<PaymentType>> _paymentButtons;
        public ObservableCollection<CommandButtonViewModel<PaymentType>> PaymentButtons
        {
            get { return _paymentButtons; }
        }

        private ICaptionCommand _makePaymentCommand;
        private ICaptionCommand _settleCommand;
        private ICaptionCommand _closeCommand;

        public void SetButtonCommands(ICaptionCommand makePaymentCommand, ICaptionCommand settleCommand, ICaptionCommand closeCommand)
        {
            _makePaymentCommand = makePaymentCommand;
            _settleCommand = settleCommand;
            _closeCommand = closeCommand;
        }

        public void Update(IEnumerable<PaymentType> paymentTypes, ForeignCurrency foreignCurrency)
        {
            _paymentButtons.Clear();
            _paymentButtons.AddRange(CreatePaymentButtons(paymentTypes, foreignCurrency));
        }

        private IEnumerable<CommandButtonViewModel<PaymentType>> CreatePaymentButtons(IEnumerable<PaymentType> paymentTypes, ForeignCurrency foreignCurrency)
        {
            var result = new List<CommandButtonViewModel<PaymentType>>();
            if (_settleCommand != null)
            {
                result.Add(new CommandButtonViewModel<PaymentType>
                {
                    Caption = Resources.Settle,
                    Command = _settleCommand,
                });
            }

            var pts = foreignCurrency == null ? paymentTypes.Where(x => x.Account == null || x.Account.ForeignCurrencyId == 0) : paymentTypes.Where(x => x.Account != null && x.Account.ForeignCurrencyId == foreignCurrency.Id);
            result.AddRange(pts
                .OrderBy(x => x.SortOrder)
                .Select(x => new CommandButtonViewModel<PaymentType>
                {
                    Caption = x.Name.Replace(" ", "\r"),
                    Command = _makePaymentCommand,
                    Color = x.ButtonColor,
                    FontSize = x.FontSize,
                    Parameter = x
                }));

            if (_closeCommand != null)
            {
                result.Add(new CommandButtonViewModel<PaymentType>
                {
                    Caption = Resources.Close,
                    Command = _closeCommand,
                    Color = "Red"
                });
            }
            return result;
        }
    }
}
