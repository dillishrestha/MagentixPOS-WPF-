using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Accounts;
using Magentix.Infrastructure.Data;

namespace Magentix.Domain.Models.Tickets
{
    public class ChangePayment:ValueClass
    {
        public ChangePayment()
        {
            Date = DateTime.Now;
        }

        public int ChangePaymentTypeId { get; set; }
        public int TicketId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int AccountTransactionId { get; set; }
        public virtual AccountTransaction AccountTransaction { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
