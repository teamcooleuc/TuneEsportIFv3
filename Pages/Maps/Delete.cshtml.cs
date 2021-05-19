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
    public class DeleteModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public DeleteModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Map = await _context.Maps.FindAsync(id);

            if (Map != null)
            {
                _context.Maps.Remove(Map);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
