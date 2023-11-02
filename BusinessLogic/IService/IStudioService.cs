using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface IStudioService
{
    List<Studio> Search(string name);
    Studio GetById(Guid id);
    Studio Update(Guid id, Studio studio);
    Studio Delete(Guid id);
    Studio Create(Studio studio);
}