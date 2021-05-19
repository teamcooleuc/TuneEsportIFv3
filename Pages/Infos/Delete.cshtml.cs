using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Pages.Infos
{
    public class DeleteModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public DeleteModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Info Info { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Info = await _context.Infos.FirstOrDefaultAsync(m => m.infoId == id);

            if (Info == null)
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

            Info = await _context.Infos.FindAsync(id);

            if (Info != null)
            {
                _context.Infos.Remove(Info);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
