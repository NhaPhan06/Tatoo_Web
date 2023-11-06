using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.SchedulePage
{
    public class ScheduleViewModel : PageModel
    {
        private int userID;
        
        private readonly ISchedulingService m_schedulingService;

        public ScheduleViewModel(ISchedulingService schedulingService)
        {
            m_schedulingService = schedulingService;
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToPage("./Login");
            }            
            return Page();
        }
        public ActionResult OnPost()
        {   
            return Page();
        }
    }
}
