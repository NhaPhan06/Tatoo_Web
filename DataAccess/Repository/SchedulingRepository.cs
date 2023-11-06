﻿using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;

namespace DataAccess.Repository;

public class SchedulingRepository: GenericRepository<Scheduling>, ISchedulingRepository
{
    private readonly TatooWebContext _context;
    public SchedulingRepository(TatooWebContext context) : base(context)
    {        
        _context = context;
    }

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
}