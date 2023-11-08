using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Presentaion.Pages.SchedulePage
{
    public class ScheduleCreateModel : PageModel
    {
        private readonly ISchedulingService _schedulingService;

        public ScheduleCreateModel (ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }
        [BindProperty]
        public Scheduling schedule { get; set; } = default!;
        [BindProperty]
        public Guid bookingID { get; set; }
        public IActionResult OnGet(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToPage("./ScheduleView");
            } else
            {
                bookingID = id;
                return Page();
            }
        }
        public IActionResult OnPost(Guid bookingid)
        {
            if (schedule == null)
            {
                return Page();
            } else
            {
                Guid id = Guid.NewGuid();
                schedule.Id = id;
                schedule.BookingId = bookingid;
                string startTime = Request.Form["StartTime"].ToString();
                schedule.StartTime = TimeSpan.ParseExact(startTime, @"hh\:mm", CultureInfo.InvariantCulture);
                string endTime = Request.Form["EndTime"].ToString();
                schedule.EndTime = TimeSpan.ParseExact(endTime, @"hh\:mm", CultureInfo.InvariantCulture);
                schedule.Status = "ONPROCESS";
                _schedulingService.Create(schedule);
                _schedulingService.SaveChanges();
            }
            return RedirectToPage("./ScheduleView");
        }
    }
}
