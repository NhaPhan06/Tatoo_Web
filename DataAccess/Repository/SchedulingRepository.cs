﻿using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class SchedulingRepository: GenericRepository<Scheduling>, ISchedulingRepository
{
    private readonly TatooWebContext _context;
    public SchedulingRepository(TatooWebContext context) : base(context)
    {        
        _context = context;
    }

	public IEnumerable<Scheduling> GetAll() => _context.Schedulings.Include(c => c.Booking).ToList();

    public Scheduling Create(Scheduling scheduling)
    {
        _context.Set<Scheduling>().Add(scheduling);
        return scheduling;
    }

    public Scheduling Delete(Scheduling scheduling)
    {
        scheduling.Status = "Cancel";
        Update(scheduling); 
        return scheduling;
        
    }

    public Scheduling GetById(Guid id)
    {
        return _context.Set<Scheduling>().FirstOrDefault(c => c.Id == id);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    Scheduling ISchedulingRepository.Update(Scheduling scheduling)
    {
        _context.Set<Scheduling>().Update(scheduling);
        return scheduling;
    }
    public Customer GetCustomerByID(Guid id)
    {
        return _context.Set<Customer>().FirstOrDefault(c => c.Id == id);
    }
    public Account GetAccountByID(Guid id)
    {
        return _context.Set<Account>().FirstOrDefault(a => a.Id == id);
    }
}