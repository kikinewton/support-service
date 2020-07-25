using SupportService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportService.Interfaces
{
    public interface IProductRepository
    {

        Product Add(Product product);
        IEnumerable<Product> GetProducts();
        string GetName(int id);
    }
}
