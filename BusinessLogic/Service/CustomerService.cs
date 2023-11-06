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

    /*public Customer GetCusById(Guid id)
    {
        return _unitOfWork.Customer.GetCusById(id);
    }*/

    /*public Customer Update(Guid id, Customer customer, Account account)
    {
        var cus = _unitOfWork.Customer.GetCusById(id);
        var acc = _unitOfWork.Account.GetById(id);

        if (acc.Email == account.Email &&
            acc.Phone == account.Phone &&
            cus.FirstName == customer.FirstName &&
            cus.LastName == customer.LastName &&
            cus.Address == customer.Address)
        {
            throw new Exception("Nothing change!");
        }


        *//*else
        {
            stu.StudioEmail = studio.StudioEmail;
            stu.StudioPhone = studio.StudioPhone;
            stu.Name = studio.Name;
            stu.Address = studio.Address;
        }*//*


        if (acc.Email != account.Email)
        {
            acc.Email = account.Email;
            var checkEmail = _unitOfWork.Customer.IsEmailExist(acc.Email);
            if (checkEmail == true)
            {
                throw new Exception("Email used!");
            }
        }
        if (acc.Phone != account.Phone)
        {
            acc.Phone = account.Phone;
            var checkPhone = _unitOfWork.Customer.IsPhoneExist(acc.Phone);
            if (checkPhone == true)
            {
                throw new Exception("Number phone used!");
            }
        }
        cus.Address = customer.Address;
        var update = _unitOfWork.Customer.Update(cus);
        _unitOfWork.Customer.SaveChanges();
        return update;*/


}