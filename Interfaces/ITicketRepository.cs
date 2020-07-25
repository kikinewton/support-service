using SupportService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportService.Interfaces
{
    public interface ITicketRepository
    {
        Ticket Add(Ticket ticket);
        Task<List<Ticket>> GetTickets();

    }
}
