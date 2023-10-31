using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IStudioService
{
    Task<Studio> getStudio(Guid guid);
    
}