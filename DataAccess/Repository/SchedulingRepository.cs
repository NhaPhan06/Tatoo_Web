using DataAccess.DataAccess;
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

}