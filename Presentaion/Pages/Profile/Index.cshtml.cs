using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;
        public IndexModel(ICustomerService customerService, IAccountService accountService)
        {
            _customerService = customerService;
            _accountService = accountService;
        }
        [BindProperty]
        public Customer customer { get; set; } = default;
        public IActionResult OnGet(Guid id)
        {
            customer = (Customer)_customerService.GetAll();
            return Page();
        }
    }
}
