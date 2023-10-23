using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;
using DataAccess.DataAccess;

namespace Presentaion.Pages.Studios
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.TatooWebContext _context;

        public CreateModel(DataAccess.TatooWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Studio Studio { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Studios == null || Studio == null)
            {
                return Page();
            }

            _context.Studios.Add(Studio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
