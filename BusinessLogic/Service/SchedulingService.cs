using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class SchedulingService : ISchedulingService
{
    private readonly IUnitOfWork _unitOfWork;
    public SchedulingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<Scheduling> GetAll() => _unitOfWork.Schedule.GetAll().ToList();
}