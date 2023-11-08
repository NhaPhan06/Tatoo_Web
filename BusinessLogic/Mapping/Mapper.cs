﻿    using AutoMapper;
using BusinessLogic.DTOS;
using BusinessLogic.DTOS.Account;
using BusinessLogic.DTOS.Artist;
using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;

namespace BusinessLogic.Mapping;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<CreateStudio, Studio>()
            .ForMember(c=> c.Id, act =>act.MapFrom(src => Guid.NewGuid()))
            .ForMember(c => c.Name, act => act.MapFrom(src => src.Name))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.StudioPhone, act => act.MapFrom(src => src.StudioPhone))
            .ForMember(c => c.StudioEmail, act => act.MapFrom(src => src.StudioEmail))
            .ForMember(c => c.Status, act => act.MapFrom(src => StudioStatus.ACTIVE.ToString()))
            .ForMember(c => c.Account, act => act.MapFrom(src => new Account
            {
                Id = Guid.NewGuid(),
                UserName = src.UserName,
                Password = src.Password,
                Email = src.StudioEmail,
                CreateDate = DateTime.Now,
                Phone = src.StudioPhone,
                Role = Role.STAFF.ToString(),
                Status = Status.ACTIVE.ToString(),
                DateOfBirth = src.DateOfBirth
            }));
        
        CreateMap<CreateCustomer, Customer>()
            .ForMember(c=> c.Id, act =>act.MapFrom(src => Guid.NewGuid()))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.Account, act => act.MapFrom(src => new Account
            {
                Id = Guid.NewGuid(),
                UserName = src.UserName,
                Password = src.Password,
                Email = src.Email,
                CreateDate = DateTime.Now,
                Phone = src.Phone,
                Role = Role.CUSTOMER.ToString(),
                Status = Status.ACTIVE.ToString(),
                DateOfBirth = src.DateOfBirth
            }));

        CreateMap<CreateBooking, Scheduling>()
            .ForMember(s => s.Id, act => act.MapFrom(src => Guid.NewGuid()))
            .ForMember(s => s.Date, act => act.MapFrom(src => src.DateTime))
            .ForMember(s => s.Booking, act => act.MapFrom(src => new Booking
            {
                Id = Guid.NewGuid(),
                Status = BookingStatus.Pending.ToString(),
                StudioId = src.StudioId,
                CustomerId = src.AccountId
            }))
            .ForMember(s => s.Status, act => act.MapFrom(src => ScheduleStatus.Inactive));
        CreateMap<CreateArtist, Artist>()
            .ForMember(c => c.Id, act => act.MapFrom(src => Guid.NewGuid()))
            .ForMember(c => c.Name, act => act.MapFrom(src => src.Name))
            .ForMember(c => c.StudioId, act => act.MapFrom(src => src.StudioId))
            .ForMember(c => c.Experience, act => act.MapFrom(src => src.Experience));
            
    }
}