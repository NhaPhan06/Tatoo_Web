using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.DataAccess;

namespace Presentaion.Pages.Studios
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.TatooWebContext _context;

        public IndexModel(DataAccess.TatooWebContext context)
        {
            _context = context;
        }

        public IList<Studio> Studio { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Studios != null)
            {
                Studio = await _context.Studios
                .Include(s => s.Account).ToListAsync();
            }
        }
    }
}
