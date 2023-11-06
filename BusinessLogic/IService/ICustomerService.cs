using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface ICustomerService
{
    Customer getByAccountId(Guid guid);
}