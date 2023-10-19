using AutoMapper;
using BusinessLogic.DTOS.Account;
using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class AccountService : IAccountService
{
    
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    
    public void CreateStudioAccount(CreateAccount account)
    {
        var company = _mapper.Map<Studio>(account);
        _unitOfWork.Studio.Add(company);
        _unitOfWork.Save();
    }
}