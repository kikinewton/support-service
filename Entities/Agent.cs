using Microsoft.AspNetCore.Identity;

namespace SupportService.Entities
{
    public class Agent : IdentityUser
    {


        [PersonalData]
        public string Name { get; set; }
        
        

    }
}
