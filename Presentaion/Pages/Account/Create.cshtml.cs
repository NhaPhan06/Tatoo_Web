using BusinessLogic.DTOS.Account;
using BusinessLogic.IService;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentaion.Pages.Account;

public class CreateModel : PageModel
{
    private IAccountService _accountService;

    public CreateModel(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [BindProperty] public CreateStudio CreateAccount { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        _accountService.CreateStudioAccount(CreateAccount);
        return RedirectToPage("./Index");
    }
}