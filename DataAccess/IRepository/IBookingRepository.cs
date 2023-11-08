﻿using DataAccess.DataAccess;
using DataAccess.IRepository.Generic;

namespace DataAccess.IRepository;

public interface IBookingRepository : IGenericRepository<Booking>
{
    IEnumerable<Booking> GetAll();
   
}