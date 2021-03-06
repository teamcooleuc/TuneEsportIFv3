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
    public class IndexModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public IndexModel(TuneEsportIFv2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Map> Map { get;set; }
        public List<Role> RoleList { get; set; }

        public async Task OnGetAsync()
        {
            RoleList = await _context.Roller.ToListAsync();
            Map = await _context.Maps.ToListAsync();
        }
    }
}
