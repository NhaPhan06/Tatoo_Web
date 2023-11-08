using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace Presentaion.Pages.SchedulePage
{
    public class ScheduleUpdateModel : PageModel
    {
        private readonly ISchedulingService _schedulingService;

        public ScheduleUpdateModel(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }
        [BindProperty]
        public Scheduling schedule { get; set; } = default!;
        public IActionResult OnGet(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToPage("./ScheduleView");
            }
            else
            {
                Scheduling getschedule = _schedulingService.GetById(id);
                if (getschedule != null)
                {
                    schedule = getschedule;
                }
                return Page();
            }
        }
        public IActionResult OnPost(Guid id)
        {
            if (schedule == null)
            {
                return Page();
            }
            else
            {
                Scheduling curSchedule = _schedulingService.GetById(id);
                //curSchedule.Id = id;
                curSchedule.Date = schedule.Date;
                string startTime = Request.Form["StartTime"].ToString();
                curSchedule.StartTime = TimeSpan.ParseExact(startTime, @"hh\:mm", CultureInfo.InvariantCulture);
                string endTime = Request.Form["EndTime"].ToString();
                curSchedule.EndTime = TimeSpan.ParseExact(endTime, @"hh\:mm", CultureInfo.InvariantCulture);
                curSchedule.Status = "ONPROCESS";
                _schedulingService.Update(curSchedule);    
                _schedulingService.SaveChanges();
            }
            return RedirectToPage("./ScheduleView");

        }
    }
}
