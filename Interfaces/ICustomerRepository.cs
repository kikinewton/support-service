using SupportService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportService.Interfaces
{
    public interface ICustomerRepository
    {
        
        Customer Add(Customer customer);

        IEnumerable<Customer> GetCustomers();
        //string GetName(string id);
        Task<bool> UpdateAsync(Customer customer);

        string GetCustomerByEmail(string email);


    }
}
