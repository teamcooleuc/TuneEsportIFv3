using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Pages.Scoreboard
{
    public class DetailsModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public DetailsModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ScoreBoard ScoreBoard { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScoreBoard = await _context.ScoreBoards.FirstOrDefaultAsync(m => m.ScoreId == id);

            if (ScoreBoard == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
