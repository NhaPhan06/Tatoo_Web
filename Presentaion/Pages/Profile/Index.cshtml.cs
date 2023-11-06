using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;
        private readonly ISchedulingService _schedulingService;
        private readonly IBookingService _bookingService;
        public IndexModel(ICustomerService customerService, IBookingService bookingService, ISchedulingService schedulingService)
        {
            _customerService = customerService;
            _bookingService = bookingService;
            _schedulingService = schedulingService;
        }
        public Customer Customer { get; set; } = default!;
        public List<Booking> Booking { get; set; }
        public List<Scheduling> Scheduling { get; set; }
        public void OnGet()
        {
        }
    }
}
