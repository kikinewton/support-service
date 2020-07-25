using System;
using System.ComponentModel.DataAnnotations;

namespace SupportService.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Display(Name ="Assigned To")]
        public string AssignedTo { get; set; }
        [Display(Name ="Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name ="Time")]
        public TimeSpan TimeCreated { get; set; }
        [Display(Name ="Status")]
        public string Status { get; set; }
        [Display(Name ="Customer")]
        public string IssuingCustomer { get; set; }
        //[Display(Name ="Attached File")]
        //public string AttachedFile { get; set; }
        [Display(Name = "Product")]
        public string ProductId { get; set; }
    }

    
}
