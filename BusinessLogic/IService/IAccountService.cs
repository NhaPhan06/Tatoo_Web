using BusinessLogic.DTOS.Account;

namespace BusinessLogic.IService;

public interface IAccountService
{
    void CreateStudioAccount(CreateAccount account);
}