using System.ComponentModel.Composition;
using Magentix.Domain.Models.Settings;
using Magentix.Presentation.Common;
using Magentix.Presentation.Common.Commands;
using Magentix.Presentation.Services;

namespace Magentix.Modules.PaymentModule
{
    [Export]
    public class PaymentButtonsViewModel : ObservableObject
    {
        private readonly IApplicationState _applicationState;

        [ImportingConstructor]
        public PaymentButtonsViewModel(IApplicationState applicationState)
        {
            _applicationState = applicationState;
            PaymentButtonGroup = new PaymentButtonGroupViewModel();
        }

        public PaymentButtonGroupViewModel PaymentButtonGroup { get; set; }

        public void Update(ForeignCurrency foreignCurrency)
        {
            PaymentButtonGroup.Update(_applicationState.GetPaymentScreenPaymentTypes(), foreignCurrency);
            RaisePropertyChanged(() => PaymentButtonGroup);
        }

        public void SetButtonCommands(ICaptionCommand makePaymentCommand, ICaptionCommand settleCommand, ICaptionCommand closeCommand)
        {
            PaymentButtonGroup.SetButtonCommands(makePaymentCommand, settleCommand, closeCommand);
        }
    }
}
