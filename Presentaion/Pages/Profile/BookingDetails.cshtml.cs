using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Profile
{
    public class DetailsModel : PageModel
    {
        private readonly IBookingService _bookingService;
        public DetailsModel (IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [BindProperty]
        public Booking booking { get; set; } = default;
        public IActionResult OnGet()
        {
            var book = _bookingService.GetAll();
            return Page();
        }
    }
}
