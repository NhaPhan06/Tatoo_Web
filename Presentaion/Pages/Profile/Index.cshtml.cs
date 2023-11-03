using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;
        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [BindProperty]
        public Customer customer { get; set; } = default!;
        public IActionResult OnGet(Guid id)
        {
            customer = _customerService.GetCusById(id);
            return Page();
        }
    }
}