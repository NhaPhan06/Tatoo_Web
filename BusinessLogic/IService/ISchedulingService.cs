﻿using DataAccess.DataAccess;

namespace BusinessLogic.IService;

public interface ISchedulingService
{
    IEnumerable<Scheduling> GetAll();
    Scheduling GetById(Guid id);
    Scheduling Update(Scheduling scheduling);
    Scheduling Delete(Scheduling scheduling);
    Scheduling Create(Scheduling scheduling);
    void SaveChanges();
    Customer GetCustomerByID(Guid id);
    Account GetAccountByID(Guid id);
}