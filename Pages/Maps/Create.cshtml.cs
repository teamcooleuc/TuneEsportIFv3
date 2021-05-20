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
    public class CreateModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public CreateModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        
       

        [BindProperty]
        public Map Map { get; set; }
        public List<Game> Games { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Games = await _context.Games.ToListAsync();

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Maps.Add(Map);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
