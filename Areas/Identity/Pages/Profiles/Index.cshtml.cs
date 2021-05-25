using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Areas.Identity.Pages.Profiles
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<TuneEsportIfv2User> _signInManager;
        private readonly UserManager<TuneEsportIfv2User> _userManager;
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        public TuneEsportIfv2User EsportUser { get; set; }    

            [BindProperty]

            public List<Game> Games{ get; set; }

            public IList<TrainingStat>TrainingStats { get; set; }

            public List<ScoreBoard> ScoreBoard { get; set; }



            public string TuneEsportIfv2User { get; set; }

            public IndexModel( UserManager<TuneEsportIfv2User> userManager,
                SignInManager<TuneEsportIfv2User> signInManager, TuneEsportIFv2.Data.ApplicationDbContext context)
            {
                _context = context;
                _userManager = userManager;
                _signInManager = signInManager;
            }

            [TempData]
            public string StatusMessage { get; set; }
        
            [BindProperty]
            public InputModel Input { get; set; }

            public string Username { get; set; }


            public class InputModel

            {
                [Required]
                [DataType(DataType.Text)]
                [Display(Name = "Rank")]
                public string Rank { get; set; }

                [Required]
                [Display(Name = "Team")]
                public string Team { get; set; }

                [Required]
                [Display(Name = "Nick")]
                public string Nick { get; set; }

                [Required]
                [Display(Name = "Clubname")]
                public string ClubName { get; set; }
            }

        private async Task LoadAsync(TuneEsportIfv2User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Rank = user.Rank,
                Team = user.Team,
                Nick = user.Nick,
                ClubName = user.ClubName

            };
        }


        public async Task<IActionResult> OnGetAsync(ScoreBoard scoreBoard, Game game)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            //Games = GameService.GetAllGames(game);
            TrainingStats = _context.TrainingStats.ToList();
            await LoadAsync(user);
            Games = await _context.Games.ToListAsync();
            ScoreBoard = await _context.ScoreBoards.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Input.Nick != user.Nick)
            {
                user.Nick = Input.Nick;
                    
            }
            if (Input.Rank != user.Rank)
            {
                user.Rank = Input.Rank;
            }
            if (Input.Team != user.Team)
            {
                user.Team = Input.Team;
            }
            if (Input.ClubName != user.ClubName)
            {
                user.ClubName = Input.ClubName;
            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            //return RedirectToPage("/Profiles/Index");

            //return RedirectToPage("/Account/Profiles", new { area = "Identity" });

            //return RedirectToPage("~/Areas/Identity/Pages/Profiles/Index.cshtml");

        }
    }
    }

