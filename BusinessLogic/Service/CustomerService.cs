using BusinessLogic.IService;
using DataAccess.DataAccess;
using DataAccess.IRepository;
using DataAccess.IRepository.UnitOfWork;

namespace BusinessLogic.Service;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Customer getByAccountId(Guid guid)
    {
        return _unitOfWork.Customer.getByAccount(guid);
    }
}