using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Magentix.ApiServer.Lib;
using Magentix.Domain.Models.Tickets;
using Magentix.Persistance;

namespace Magentix.ApiServer.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TicketsController : MagentixApiController
    {
        private readonly ITicketDao _ticketDao;

        [ImportingConstructor]
        public TicketsController(ITicketDao ticketDao)
        {
            _ticketDao = ticketDao;
        }

        //GET =>  http://localhost:8080/api/{token}/Tickets/
        public IEnumerable<Ticket> GetAllTickets()
        {
            ValidateToken();
            return _ticketDao.GetAllTickets();
        }

        //GET =>  http://localhost:8080/api/{token}/Tickets/{id}
        public Ticket GetTicketById(int id)
        {
            ValidateToken();
            return _ticketDao.GetTicketById(id);
        }
    }
}
