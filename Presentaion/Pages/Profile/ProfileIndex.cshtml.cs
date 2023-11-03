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
        public Customer cus { get; set; } = default;
        public void OnGet()
        {
        }
    }
}
