using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Presentaion.Pages.Account;

public class DetailsModel : PageModel
{
    private readonly TatooWebContext _context;

    public DetailsModel(TatooWebContext context)
    {
        _context = context;
    }

    public DataAccess.DataAccess.Account Account { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        if (id == null || _context.Accounts == null) return NotFound();

        var account = await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id);
        if (account == null)
            return NotFound();
        Account = account;
        return Page();
    }
}