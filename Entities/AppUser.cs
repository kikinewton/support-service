using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SupportService.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Customers = new List<Customer>();
            Agents = new List<Agent>();
        }
        public virtual ICollection<Customer> Customers { get; private set; }
        public virtual ICollection<Agent> Agents { get; private set; }
    }
}
