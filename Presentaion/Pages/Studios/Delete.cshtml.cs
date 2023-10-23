﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.TatooWebContext _context;

        public DeleteModel(DataAccess.TatooWebContext context)
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

            var studio = await _context.Studios.FirstOrDefaultAsync(m => m.Id == id);

            if (studio == null)
            {
                return NotFound();
            }
            else 
            {
                Studio = studio;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Studios == null)
            {
                return NotFound();
            }
            var studio = await _context.Studios.FindAsync(id);

            if (studio != null)
            {
                Studio = studio;
                _context.Studios.Remove(Studio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
