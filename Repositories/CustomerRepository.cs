using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using SupportService.Entities;
using Microsoft.EntityFrameworkCore;
using SupportService.Interfaces;

namespace SupportService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _customerDbContext;
        private readonly ILogger _logger;

        public CustomerRepository(AppDbContext customerDbContext, ILoggerFactory loggerFactory)
        {
            _customerDbContext = customerDbContext;
            _logger = loggerFactory.CreateLogger(nameof(CustomerRepository));
        }

        public Customer Add(Customer customer)
        {
            _ = _customerDbContext.Customers.Add(customer);
            try
            {
                _customerDbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                _logger.LogError($"Error in {nameof(Add)}: " + e.Message);
            }
            return customer;
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            _ = _customerDbContext.Customers.Attach(customer);
            _customerDbContext.Entry(customer).State = EntityState.Modified;
            try
            {
                return (await _customerDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(UpdateAsync)}: " + e.Message);
            }
            return false;
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
            var customer = await _customerDbContext.Customers.OrderBy(c => c.Name).SingleOrDefaultAsync(x => x.Id.ToString() == id);
            _customerDbContext.Remove(customer);
            try
            {
                return (await _customerDbContext.SaveChangesAsync() > 0 ? true : false);

            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(DeleteCustomerAsync)} :" + e.Message);
            }
            return false;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerDbContext.Customers.OrderBy(x => x.Name).ToList();
        }

        public async Task<Customer> GetIdAsync(string id)
        {
            return await _customerDbContext.Customers.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        }

        public string GetCustomerByEmail(string username)
        {
            return _customerDbContext.Customers.FirstOrDefault(c => c.UserName == username).Company;
        }

        //public string GetName(string id)
        //{
        //    return GetIdAsync(id).;
        //}


    }
}

        
