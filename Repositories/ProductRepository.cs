using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportService.Entities;
using SupportService.Interfaces;

namespace SupportService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _customerDbContext;
        private readonly ILogger _logger;

        public ProductRepository(AppDbContext appDbContext, ILoggerFactory loggerFactory)
        {
            this._customerDbContext = appDbContext;
            this._logger = loggerFactory.CreateLogger(nameof(ProductRepository));
        }

        public Product Add(Product product)
        {
            _customerDbContext.Products.Add(product);
            try
            {
                _customerDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(ProductRepository)} "+ e.Message);
            }
            return product;
        }

        public string GetName(int id)
        {
            return _customerDbContext.Products.FirstOrDefaultAsync(x => x.Id == id).Result.Name;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _customerDbContext.Products.OrderBy(x => x.Name).ToList();
        }
    }
}
