﻿using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(TatooWebContext context) : base(context)
    {
    }

    public Customer getByAccount(Guid guid)
    {
        return _context.Customers.FirstOrDefault(c => c.AccountId == guid);
    }
}