using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
{
    private readonly TatooWebContext _context;
    public CustomerRepository(TatooWebContext context) : base(context)
    {
        _context = context;
    }
    public IEnumerable<Customer> GetAll() => _context.Customers.ToList();
    public Customer GetCusById(Guid id)
    {
        return _context.Set<Customer>().FirstOrDefault(c => c.Id == id);
    }
    public bool IsChange(Customer cusold, Customer cusnew )
    {
        var CusOld = _context.Set<Customer>().Entry(cusold);
        var CusNew = _context.Set<Customer>().Entry(cusnew);
        if (CusOld == CusNew)
        {
            return false;
        }
        return true;
    }

   /* public bool IsEmailExist(string email)
    {
        var check = _context.Set<Account>().FirstOrDefault(c => c.Email == email);
        if (check == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool IsPhoneExist(string phone)
    {
        var check = _context.Set<Account>().FirstOrDefault(c => c.Phone == phone);
        if (check == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }*/

    public void SaveChanges()
    { 
        _context.SaveChanges();
    }
    /*Customer ICustomerRepository.Update(Customer customer, Account account)
    {
        _context.Set<Customer>().Update(customer);
        return customer;
    }*/
}