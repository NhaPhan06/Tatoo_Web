using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.DataAccess;

namespace Presentaion.Pages.Studios
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.TatooWebContext _context;

        public EditModel(DataAccess.TatooWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Studio Studio { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Studios == null)
            {
                return NotFound();
            }

            var studio =  await _context.Studios.FirstOrDefaultAsync(m => m.Id == id);
            if (studio == null)
            {
                return NotFound();
            }
            Studio = studio;
           ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Studio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudioExists(Studio.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudioExists(Guid id)
        {
          return (_context.Studios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
