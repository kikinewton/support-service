using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupportService.Entities;
using SupportService.Interfaces;
using SupportService.Model;

namespace SupportService.Controllers
{
    //[Authorize]
    public class TicketController : Controller
    {
        private readonly AppDbContext context;
        private readonly ITicketRepository ticketRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ILogger logger;
        private readonly IProductRepository productRepository;
        private UserManager<AppUser> _userManager;

        public TicketController(ITicketRepository ticketRepository,
            ICustomerRepository customerRepository,
            ILoggerFactory loggerFactory,
            IProductRepository productRepository,
            AppDbContext context,
            UserManager<AppUser> userManager)
        {
            this.context = context;
            this.ticketRepository = ticketRepository;
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
            _userManager = userManager;
            logger = loggerFactory.CreateLogger(nameof(TicketController));
        }

        [HttpGet]
        //[ProducesResponseType(typeof(List<Ticket>), 200)]
        //[ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var product = productRepository.GetProducts();
                var tickets = await ticketRepository.GetTickets();
                return View(tickets);
            }
            catch (System.Exception e)
            {
                logger.LogError($"Error in {nameof(TicketController)} " + e.Message);
                return BadRequest(new ApiResponse { Status = false });
            }

        }
        [HttpGet]
        
        public IActionResult Create()
        {
            ViewBag.Product = context.Products;
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public  IActionResult Create(Ticket ticket)
        {
            try
            {
                var username = User.Identity.Name;
                if (ModelState.IsValid)
                {
                    //ticket.IssuingCustomer = username;
                    ticketRepository.Add(ticket);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception e)
            {
                logger.LogError($"Error in { nameof(TicketController)} " + e.Message);
                return View();
            }

        }

    }
}