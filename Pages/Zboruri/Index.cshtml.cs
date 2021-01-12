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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Nitu_Andreea.Data.Proiect_Nitu_AndreeaContext _context;

        public IndexModel(Proiect_Nitu_Andreea.Data.Proiect_Nitu_AndreeaContext context)
        {
            _context = context;
        }

        public IList<Zbor> Zbor { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Airlines { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ZborAir { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> AirQuery = from m in _context.Zbor
                                          orderby m.Airline
                                          select m.Airline;
            var zbor = from m in _context.Zbor
                       select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                zbor = zbor.Where(s => s.To.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ZborAir))
            {
                zbor = zbor.Where(x => x.Airline == ZborAir);
            }
            Airlines = new SelectList(await AirQuery.Distinct().ToListAsync());
            Zbor = await zbor.ToListAsync();
            //Zbor = await _context.Zbor.ToListAsync();
        }
    }
}
