﻿using BusinessLogic.IService;
using BusinessLogic.Service;
using DataAccess;
using BusinessLogic.Mapping;
using DataAccess.IRepository;
using DataAccess.IRepository.Generic;
using DataAccess.IRepository.UnitOfWork;
using DataAccess.Repository;
using DataAccess.Repository.Generic;
using DataAccess.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Configuration;

public static class DenpendencyInjection
{
    public static IServiceCollection AddService(this IServiceCollection services, string databaseConnection)
    {
        // CONNECT DB
        services.AddDbContext<TatooWebContext>(options => { options.UseSqlServer(databaseConnection); });
        
        // SIGN UP UNIT OF WORK FOR REPO AND GENERIC
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IUnitOfWork, UnitOfWorkRepository>();
        
        // SIGN UP REPO
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<IArtistRepository, ArtistRepository>();
        services.AddTransient<IArtWorkRepository, ArtWorkRepository>();
        services.AddTransient<IDiscountRepository, DiscountRepository>();
        services.AddTransient<IEquipmentRepository, EquipmentRepository>();
        services.AddTransient<IImageRepository, ImageRepository>();
        services.AddTransient<ISchedulingRepository, SchedulingRepository>();
        services.AddTransient<IStudioRepository, StudioRepository>();
        services.AddTransient<IVipMemberRepository, VipMemberRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();



        // SIGN UP SERVICE
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<IArtistService, ArtistService>();
        services.AddTransient<IArtworkService, ArtworkService>();
        services.AddTransient<IBookingService, BookingService>();
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IDiscountService, DiscountService>();
        services.AddTransient<IEquipmentService, EquipmentService>();
        services.AddTransient<IImageService, ImageService>();
        services.AddTransient<ISchedulingService, SchedulingService>();
        services.AddTransient<IStudioService, StudioService>();
        services.AddTransient<IVipmemberService, VipmemberService>();
        
        //AUTOMAPPER
        services.AddAutoMapper(typeof(Mapper).Assembly);
        
        

        
        return services;
    }
}