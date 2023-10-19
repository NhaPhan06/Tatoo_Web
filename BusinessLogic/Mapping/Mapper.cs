using AutoMapper;
using BusinessLogic.DTOS.Account;
using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;

namespace BusinessLogic.Mapping;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<CreateAccount, Studio>()
            .ForMember(c => c.Name, act => act.MapFrom(src => src.Name))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.StudioPhone, act => act.MapFrom(src => src.StudioPhone))
            .ForMember(c => c.StudioEmail, act => act.MapFrom(src => src.StudioEmail))
            .ForMember(c => c.Account, act => act.MapFrom(src => new Account
            {
                UserName = src.UserName,
                Password = src.Password,
                Email = src.Email,
                CreateDate = src.CreateDate,
                Phone = src.Phone,
                Role = Role.STAFF.ToString(),
                Status = Status.ACTIVE.ToString(),
                DateOfBirth = src.DateOfBirth
            }));
    }
}