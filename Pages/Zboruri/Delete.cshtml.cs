﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Nitu_Andreea.Data;
using Proiect_Nitu_Andreea.Models;

namespace Proiect_Nitu_Andreea.Pages.Zboruri
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Nitu_Andreea.Data.Proiect_Nitu_AndreeaContext _context;

        public DeleteModel(Proiect_Nitu_Andreea.Data.Proiect_Nitu_AndreeaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Zbor Zbor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Zbor = await _context.Zbor.FirstOrDefaultAsync(m => m.ID == id);

            if (Zbor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Zbor = await _context.Zbor.FindAsync(id);

            if (Zbor != null)
            {
                _context.Zbor.Remove(Zbor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
