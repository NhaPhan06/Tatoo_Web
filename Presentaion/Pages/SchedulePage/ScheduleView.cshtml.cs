using BusinessLogic.IService;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Presentaion.Pages.SchedulePage
{
    public class ScheduleViewModel : PageModel
    {
        private readonly ISchedulingService m_schedulingService;

        private readonly IBookingService m_bookingService;

        public ScheduleViewModel(ISchedulingService schedulingService, IBookingService bookingService)
        {
            m_schedulingService = schedulingService;
            m_bookingService = bookingService;
        }

        public IList<Customer> Customers { get; set; } = default!;

        public IList<Scheduling> Schedulings { get; set; } = default!;

        public IList<Booking> Bookings { get; set; } = default!;

        public IList<Account> Accounts { get; set; } = default;
        public IActionResult OnGet()
        {
            string userName = HttpContext.Session.GetString("AccountID");
            if (userName == null)
            {
                //return RedirectToPage("/LoginPage");
            }            
            if (m_bookingService.GetAll() != null)
            {
                List<Customer> listGetCus = new List<Customer>();
                List<Account> listGetAcc = new List<Account>();

                Bookings = m_bookingService.GetAll().ToList();
                if (Bookings.Count > 0) { 
                    foreach (var booking in Bookings)
                    {
                        Customer customer = m_schedulingService.GetCustomerByID(((Guid)booking.CustomerId));                        
                        listGetCus.Add(customer);
                        Account account = m_schedulingService.GetAccountByID((Guid)customer.AccountId);
                        listGetAcc.Add(account);
                    }
                    Customers = listGetCus.ToList();
                    Accounts = listGetAcc.ToList();
                }
            }
            if (m_schedulingService.GetAll() != null)
            {
                Schedulings = m_schedulingService.GetAll().ToList();    
            }
            return Page();
        }
        public IActionResult OnGetBookingCancel(Guid id)
        {
            Booking curBooking = new Booking();
            //curBooking = m_bookingService.GetById(id);
            //curBooking.Status = "CANCEL";
            //m_bookingService.Update(curBooking);
            //m_bookingService.SaveChanges();

            if (m_bookingService.GetAll() != null)
            {
                List<Customer> listGetCus = new List<Customer>();
                List<Account> listGetAcc = new List<Account>();

                Bookings = m_bookingService.GetAll().ToList();
                if (Bookings.Count > 0)
                {
                    foreach (var booking in Bookings)
                    {
                        Customer customer = m_schedulingService.GetCustomerByID(((Guid)booking.CustomerId));
                        listGetCus.Add(customer);
                        Account account = m_schedulingService.GetAccountByID((Guid)customer.AccountId);
                        listGetAcc.Add(account);
                    }
                    Customers = listGetCus.ToList();
                    Accounts = listGetAcc.ToList();
                }
            }
            if (m_schedulingService.GetAll() != null)
            {
                Schedulings = m_schedulingService.GetAll().ToList();
            }
            return Page();
        }
        public IActionResult OnGetCancel(Guid id)
        {
            Scheduling scheduling = new Scheduling();
            scheduling = m_schedulingService.GetById(id);
            scheduling.Status = "CANCEL";
            m_schedulingService.Update(scheduling);
            m_schedulingService.SaveChanges();

            if (m_bookingService.GetAll() != null)
            {
                List<Customer> listGetCus = new List<Customer>();
                List<Account> listGetAcc = new List<Account>();

                Bookings = m_bookingService.GetAll().ToList();
                if (Bookings.Count > 0)
                {
                    foreach (var booking in Bookings)
                    {
                        Customer customer = m_schedulingService.GetCustomerByID(((Guid)booking.CustomerId));
                        listGetCus.Add(customer);
                        Account account = m_schedulingService.GetAccountByID((Guid)customer.AccountId);
                        listGetAcc.Add(account);
                    }
                    Customers = listGetCus.ToList();
                    Accounts = listGetAcc.ToList();
                }
            }
            if (m_schedulingService.GetAll() != null)
            {
                Schedulings = m_schedulingService.GetAll().ToList();
            }
            return Page();
        }
    }
}
