using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    IEnumerable<Customer> GetAll();
    Customer GetCusById(Guid id);
    /*Customer Update(Customer customer);*/
    void SaveChanges();
    /*Boolean IsEmailExist(string email);
    Boolean IsPhoneExist(string phone);
    Boolean IsChange(Customer cusold, Customer cusnew);*/
}