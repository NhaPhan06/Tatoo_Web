using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();

    /* Customer Update(Guid id, Customer customer,Account account);*/
    Customer getByAccountId(Guid guid);
}