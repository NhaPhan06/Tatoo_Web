using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Profile
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public EditModel (ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [BindProperty]
        public Customer Customer { get; set; } = default!;
        public IActionResult OnGet(Guid id)
        {
            try
            {
                Customer = _customerService.GetCustomerById(id);
                return Page();
            }
            catch (Exception ex) {
                TempData["Error message"] = ex.Message;
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            try
            {
                Customer = _customerService.UpdateCustomer(Customer.Id, Customer);
                return Redirect("/Profile/Index");
            }
            catch(Exception ex)
            {
                TempData["Error Message"] = ex.Message;
            }
            return Page();
        }
    }
    
}
