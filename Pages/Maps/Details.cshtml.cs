using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Pages.Maps
{
    public class DetailsModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public DetailsModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Map Map { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Map = await _context.Maps.FirstOrDefaultAsync(m => m.mapsId == id);

            if (Map == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
