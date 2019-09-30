using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Magentix.Domain.Models.Tickets;
using Magentix.Persistance.Common;

namespace Magentix.Persistance
{
    public interface ITicketDao
    {
        TicketCommitResult CheckConcurrency(Ticket ticket);
        void Save(Ticket ticket);
        Ticket OpenTicket(int ticketId);
        int GetOpenTicketCount();
        IEnumerable<int> GetOpenTicketIds(int entityId);
        IEnumerable<OpenTicketData> GetOpenTickets(Expression<Func<Ticket, bool>> prediction);
        IEnumerable<Ticket> GetFilteredTickets(DateTime startDate, DateTime endDate, IList<ITicketExplorerFilter> filters);
        IEnumerable<Order> GetOrders(int ticketId);
        void SaveFreeOrderTag(int orderTagGroupId, OrderTag orderTag);
        void SaveFreeTicketTag(int ticketTagGroupId, string freeTag);
        IEnumerable<Ticket> GetAllTickets();
        Ticket GetTicketById(int id);
    }
}
