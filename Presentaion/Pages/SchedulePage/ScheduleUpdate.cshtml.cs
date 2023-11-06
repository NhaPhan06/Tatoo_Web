using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.SchedulePage
{
    public class ScheduleUpdateModel : PageModel
    {
        private readonly ISchedulingService _schedulingService;

        public ScheduleUpdateModel(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }
        public Scheduling schedule { get; set; } = default!;
        public IActionResult OnGet(Guid id)
        {
            string inputString = "";
            bool isValid = Guid.TryParse(inputString, out id);
            if (isValid == false)
            {
                //return RedirectToPage("./ScheduleView");
                return Page();
            }
            else
            {
                schedule.BookingId = id;
                return Page();
            }
        }
        public IActionResult OnPost()
        {
            if (schedule == null)
            {
                return Page();
            }
            else
            {
                string startTime = Request.Form["StartTime"].ToString();
                schedule.StartTime = TimeSpan.Parse(startTime);
                string endTime = Request.Form["EndTime"].ToString();
                schedule.StartTime = TimeSpan.Parse(endTime);
                _schedulingService.Update(schedule);
                _schedulingService.SaveChanges();
            }

            return RedirectToPage("./ScheduleView");
        }
    }
}
