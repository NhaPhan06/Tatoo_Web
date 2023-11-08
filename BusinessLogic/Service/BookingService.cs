﻿using AutoMapper;
using BusinessLogic.DTOS;
using BusinessLogic.IService;
using BusinessLogic.Mapping;
using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;
using DataAccess.IRepository.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessLogic.Service;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<bool> CreateBooking(Guid id, DateTime date, Guid studioID)
    {
        var customer = _unitOfWork.Customer.getByAccount(id);
        var booking =  new CreateBooking(customer.Id, date, studioID);
        var b = _mapper.Map<Scheduling>(booking);
        _unitOfWork.Schedule.Add(b);
        _unitOfWork.Save();
        return true;
    }
    public IEnumerable<Booking> GetAll() => _unitOfWork.Booking.GetAll().ToList();
}


    