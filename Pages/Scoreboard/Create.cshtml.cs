using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Data;
using TuneEsportIFv2.Models;
using TuneEsportIFv2.Services.Interfaces;

namespace TuneEsportIFv2.Pages.Scoreboard
{
    public class CreateModel : PageModel 
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;
        private readonly UserManager<TuneEsportIfv2User> _userManager;

        [BindProperty]
        public ScoreBoard ScoreBoard { get; set; }
       
        public string Username { get; set; }


        public CreateModel(TuneEsportIFv2.Data.ApplicationDbContext context, UserManager<TuneEsportIfv2User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Map> maps { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            maps = await _context.Maps.ToListAsync();

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

            _context.ScoreBoards.Add(ScoreBoard);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
