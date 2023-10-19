using DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Presentaion.Pages.Account;

public class IndexModel : PageModel
{
    private readonly TatooWebContext _context;

    public IndexModel(TatooWebContext context)
    {
        _context = context;
    }

    public IList<DataAccess.DataAccess.Account> Account { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Accounts != null) Account = await _context.Accounts.ToListAsync();
    }
}