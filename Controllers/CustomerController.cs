using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SupportService.Entities;
using SupportService.Interfaces;
using SupportService.Model;

namespace SupportService.Controllers
{
    
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger _logger;

        public CustomerController(ICustomerRepository customerRepository, ILoggerFactory loggerFactory)
        {
            _customerRepository = customerRepository;
            _logger = loggerFactory.CreateLogger(nameof(CustomerController));
        }



        // GET: api/Customer
        [HttpGet]
        [ProducesResponseType(typeof(List<Customer>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public IActionResult Get()
        {
            try
            {
                var customers =  _customerRepository.GetCustomers();
                return Ok(customers);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(CustomerController)}:" + e.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
            
            
        }

        // GET: api/Customer/5
        //[HttpGet("{id}", Name = "Get")]
        //public string GetCustomerName(string id)
        //{
        //    return _customerRepository.GetName(id);
        //}

        public IActionResult Index()
        {
            var customers = _customerRepository.GetCustomers();
            //ViewBag.Customers = customers;
            return View(customers);
        }

        // POST: api/Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);

        }

        public IActionResult Register()
        {
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetCustomers(), "Id", "Id");
            return View();
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
