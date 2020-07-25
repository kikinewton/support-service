using System.ComponentModel.DataAnnotations;

namespace SupportService.Models
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(50), Display(Name = "Name")]
        
        public string Name { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [Required, DataType(DataType.PhoneNumber), Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password)), Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Company Name")]
        public string Company { get; set; }



    }
}
