using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SupportService.Entities
{
        
    public class Customer : IdentityUser
    {
        
        [PersonalData]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [PersonalData]
        public string Address { get; set; }
        

        [PersonalData]
        public string Company { get; set; }


    }
}
