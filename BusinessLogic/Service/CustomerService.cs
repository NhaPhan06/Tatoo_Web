using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Customer> GetAll() => _unitOfWork.Customer.GetAll().ToList();

    public Customer GetCustomerById(Guid id)
    {
        return _unitOfWork.Customer.GetById(id);
    }


    public Customer UpdateCustomer(Guid id, Customer customer)
    {
        var cus = _unitOfWork.Customer.GetById(id);
        if (cus.Account.UserName == customer.Account.UserName&&
            cus.Account.Password == customer.Account.Password&&
            cus.FirstName == customer.FirstName&&
            cus.LastName == customer.LastName&&
            cus.Address == customer.Address&&
            cus.Account.Email == customer.Account.Email&&
            cus.Account.Phone == customer.Account.Phone&&
            cus.Account.DateOfBirth == customer.Account.DateOfBirth)
        {
            throw new Exception("Nothing change");
        }
        cus.Account.UserName = customer.Account.UserName;
        cus.Account.Password = customer.Account.Password;
        cus.FirstName = customer.FirstName;
        cus.LastName = customer.LastName;
        cus.Address = customer.Address;
        cus.Account.Email = customer.Account.Email;
        cus.Account.Phone = customer.Account.Phone;
        cus.Account.DateOfBirth = customer.Account.DateOfBirth;
        var update = _unitOfWork.Customer.UpdateCustomer(cus);
        _unitOfWork.Customer.SaveChanges();
        return update;
    }


}