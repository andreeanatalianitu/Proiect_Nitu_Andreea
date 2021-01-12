using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Nitu_Andreea.Data;
using Proiect_Nitu_Andreea.Models;

namespace Proiect_Nitu_Andreea.Pages.Zboruri
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Nitu_Andreea.Data.Proiect_Nitu_AndreeaContext _context;

        public CreateModel(Proiect_Nitu_Andreea.Data.Proiect_Nitu_AndreeaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Zbor Zbor { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Zbor.Add(Zbor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
