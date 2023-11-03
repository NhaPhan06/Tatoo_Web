using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Service;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;
    public BookingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<Booking> GetAll() => _unitOfWork.Booking.GetAll().ToList();
    
}   