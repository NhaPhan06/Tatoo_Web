using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class BookingRepository: GenericRepository<Booking>, IBookingRepository
{
    private readonly TatooWebContext _context;
    public BookingRepository(TatooWebContext context) : base(context)
    {
        _context = context;
    }
    public IEnumerable<Booking> GetAll() => _context.Bookings.Include(c => c.Schedulings).ToList();
    
}