using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface ICustomerService
{
    Customer GetCusById(Guid id);
    /* Customer Update(Guid id, Customer customer,Account account);*/
}