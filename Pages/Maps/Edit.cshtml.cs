using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Pages.Maps
{
    public class EditModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public EditModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Map Map { get; set; }
        public List<Game> Games { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Games = await _context.Games.ToListAsync();
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Map).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapExists(Map.mapsId))
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

        private bool MapExists(int id)
        {
            return _context.Maps.Any(e => e.mapsId == id);
        }
    }
}
