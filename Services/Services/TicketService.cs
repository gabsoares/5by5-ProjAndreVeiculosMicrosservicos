using Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TicketService
    {
        private TicketRepository _ticketRepository;

        public TicketService()
        {
            _ticketRepository = new TicketRepository();
        }

        public async Task<List<Ticket>> GetAllTickets(byte type)
        {
            return await _ticketRepository.GetAllTickets(type);
        }
    }
}