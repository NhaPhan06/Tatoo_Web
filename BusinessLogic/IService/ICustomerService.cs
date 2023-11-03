using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();
    Customer GetCusById(Guid id);
   /* Customer Update(Guid id, Customer customer,Account account);*/
}