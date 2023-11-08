using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface ICustomerService
{
    Customer getByAccountId(Guid guid);
	IEnumerable<Customer> GetAll();

    /* Customer Update(Guid id, Customer customer,Account account);*/}