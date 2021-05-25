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
    public class IndexModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public IndexModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; }
        public List<Role> RoleList { get; set; }

        public async Task OnGetAsync()
        {
            RoleList = await _context.Roller.ToListAsync();
            Game = await _context.Games.ToListAsync();
        }
    }
}
