using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Magentix.Domain.Models.Entities;
using Magentix.Domain.Models.Tickets;
using Magentix.Persistance.Common;

namespace Magentix.Services
{
    public interface ITicketServiceBase
    {
        IEnumerable<Ticket> GetFilteredTickets(DateTime startDate, DateTime endDate, IList<ITicketExplorerFilter> filters);
        IList<ITicketExplorerFilter> CreateTicketExplorerFilters();
        IEnumerable<Order> GetOrders(int ticketId);
        IEnumerable<OpenTicketData> GetOpenTickets(Expression<Func<Ticket, bool>> prediction);
        IEnumerable<OpenTicketData> GetOpenTickets(int entityId);
        IEnumerable<int> GetOpenTicketIds(int entityId);
        int GetOpenTicketCount();
        void UpdateAccountOfOpenTickets(Entity entity);
        IEnumerable<Ticket> GetTicketsByState(string state);
    }
}
