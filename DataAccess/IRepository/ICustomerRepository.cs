using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Customer getByAccount(Guid guid);
    IEnumerable<Customer> GetAll();
    /*Customer Update(Customer customer);*/
    /*void SaveChanges();*/
    /*Boolean IsEmailExist(string email);
    Boolean IsPhoneExist(string phone);
    Boolean IsChange(Customer cusold, Customer cusnew);*/
}