using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IBookingService
{
    IEnumerable<Booking> GetAll();
    
}