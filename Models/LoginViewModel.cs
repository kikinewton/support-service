using System.ComponentModel.DataAnnotations;

namespace SupportService.Models
{
    public class LoginViewModel
    {
        [Required,MaxLength(50)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

    }
}
