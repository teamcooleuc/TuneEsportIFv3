using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Pages.Scoreboard
{
    public class dataModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;
        private readonly UserManager<TuneEsportIfv2User> _userManager;

        [BindProperty]
        public ScoreBoard ScoreBoard { get; set; }

        public string Username { get; set; }
        public List<ScoreBoard> ScoreBoards { get; set; }
        public List<Map> Maps { get; set; }

        public List<Role> RoleList { get; set; }


        public dataModel(TuneEsportIFv2.Data.ApplicationDbContext context, UserManager<TuneEsportIfv2User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Maps = await _context.Maps.ToListAsync();
            ScoreBoards = await _context.ScoreBoards.ToListAsync();
            RoleList = await _context.Roller.ToListAsync();

            return Page();
        }

        //Should get the username and past it into creation of scoreboard field.
        private async Task LoadAsync(TuneEsportIfv2User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);


            Username = userName;

        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //This small part, Post into DB - The current user info
            //var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            //}
            var user = await _userManager.GetUserAsync(User);

            if (!ModelState.IsValid)
            {
                //await LoadAsync(user);
                return Page();
            }

            ScoreBoard.TuneEsportIfv2User = user.Id;
            ScoreBoard.Date = DateTime.Today;

            await _context.ScoreBoards.AddAsync(ScoreBoard);
            await _context.SaveChangesAsync();

            return RedirectToPage("./data");
        }
    }
}
