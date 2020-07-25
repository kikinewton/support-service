using Microsoft.EntityFrameworkCore;
using SupportService.Models;
using SupportService.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SupportService.Entities
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<SupportService.Models.CustomerModel> CustomerModel { get; set; }
        //public DbSet<SupportService.Entities.AppUser> AppUser { get; set; }

        

    }
}
