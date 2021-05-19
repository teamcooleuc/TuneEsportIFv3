using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public DetailsModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Games.FirstOrDefaultAsync(m => m.gameID == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
