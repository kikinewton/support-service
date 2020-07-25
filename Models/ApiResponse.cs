using Microsoft.AspNetCore.Mvc.ModelBinding;
using SupportService.Entities;

namespace SupportService.Model
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public Customer Customer { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}