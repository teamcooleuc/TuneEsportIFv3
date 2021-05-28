using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Models;


namespace TuneEsportIFv2.Pages.Members
{
    public class MembersModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;
        private readonly UserManager<TuneEsportIfv2User> _userManager;

        [BindProperty]
        public List<Game> Games { get; set; }

        public Role Role { get; set; }
        public Areas.Identity.Pages.Profiles.IndexModel.InputModel Input { get; set; }

        public List<Areas.Identity.Pages.Profiles.IndexModel.InputModel> Inputs { get; set; }

        public List<ScoreBoard> ScoreBoards { get; set; }
        public List<Role> RoleList { get; set; }

        public MembersModel(TuneEsportIFv2.Data.ApplicationDbContext context, UserManager<TuneEsportIfv2User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task <IActionResult> OnGetAsync(ScoreBoard scoreBoard, TuneEsportIfv2User tuneEsportIfv2User, Role role)
        {
            Games = await _context.Games.ToListAsync();
            ScoreBoards = await _context.ScoreBoards.ToListAsync();
            RoleList = await _context.Roller.ToListAsync();
            
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user1 = await _context.Roller.FindAsync(id);

            if (!ModelState.IsValid)
            {
                //await LoadAsync(user);
                return Page();
            }

            //await _context.Roller.AddAsync(Role);
            _context.Attach(user1).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Page();
        }

    }
}
