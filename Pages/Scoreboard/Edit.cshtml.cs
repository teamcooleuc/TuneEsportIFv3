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

namespace TuneEsportIFv2.Pages.Scoreboard
{
    public class EditModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public EditModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScoreBoard ScoreBoard { get; set; }
        public TrainingStats TrainingStat { get; set; }

        public List<TrainingStats> TrainingStats { get; set; }

        public async Task<IActionResult> OnGetAsync(double? id)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ScoreBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreBoardExists(ScoreBoard.ScoreId))
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

        private bool ScoreBoardExists(double id)
        {
            return _context.ScoreBoards.Any(e => e.ScoreId == id);
        }
    }
}
