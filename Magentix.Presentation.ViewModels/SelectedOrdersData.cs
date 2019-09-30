using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magentix.Domain.Models.Tickets;

namespace Magentix.Presentation.ViewModels
{
    public class SelectedOrdersData
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<Order> SelectedOrders { get; set; }
    }
}
