using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SupportService.Entities;
using SupportService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportService.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _AppDbContext;
        private readonly ILogger _logger;
        
        //private Task<AppUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public TicketRepository(AppDbContext AppDbContext, ILoggerFactory loggerFactory)
        {
            this._AppDbContext = AppDbContext;
            this._logger = loggerFactory.CreateLogger(nameof(TicketRepository));
        }
        public Ticket Add(Ticket ticket)
        {
            ticket.DateCreated = DateTime.Now;
            ticket.TimeCreated = DateTime.Now.TimeOfDay;
            ticket.Status = "Open";
            ticket.IssuingCustomer = "Toast Maker";
            ticket.ProductId = "Azure Insight";
            ticket.AssignedTo = "";
            


            _AppDbContext.Tickets.Add(ticket);
            try
            {
                _AppDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(TicketRepository)}: " + e.Message);
            }
            return ticket;
        }

        public async Task<List<Ticket>> GetTickets()
        {
            return await _AppDbContext.Tickets.OrderBy(x => x.Subject).ToListAsync();
        }
    }
}
