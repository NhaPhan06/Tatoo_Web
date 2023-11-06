using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface ISchedulingService
{
    IEnumerable<Scheduling> GetAll();
}