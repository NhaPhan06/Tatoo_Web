using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();
    Customer UpdateCustomer(Guid id, Customer customer);
    Customer GetCustomerById(Guid id);
    /* Customer Update(Guid id, Customer customer,Account account);*/
}