using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Nitu_Andreea.Data;
using Proiect_Nitu_Andreea.Models;

namespace Proiect_Nitu_Andreea.Pages.Zboruri
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Nitu_Andreea.Data.Proiect_Nitu_AndreeaContext _context;

        public EditModel(Proiect_Nitu_Andreea.Data.Proiect_Nitu_AndreeaContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Zbor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZborExists(Zbor.ID))
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

        private bool ZborExists(int id)
        {
            return _context.Zbor.Any(e => e.ID == id);
        }
    }
}
