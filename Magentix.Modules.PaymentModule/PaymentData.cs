using Magentix.Domain.Models.Tickets;

namespace Magentix.Modules.PaymentModule
{
    public class PaymentData
    {
        public PaymentType PaymentType { get; set; }
        public ChangePaymentType ChangePaymentType { get; set; }
        public decimal PaymentDueAmount { get; set; }
        public decimal TenderedAmount { get; set; }
    }
}