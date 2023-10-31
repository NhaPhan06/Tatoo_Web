using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class StudioService : IStudioService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudioService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Studio> getStudio(Guid guid)
    {
        return _unitOfWork.Studio.GetById(guid);
    }
}