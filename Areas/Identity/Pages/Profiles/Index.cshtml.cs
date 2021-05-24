using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Models;
using TuneEsportIFv2.Services.Interfaces;
using TuneEsportIFv2.Services.Services;

namespace TuneEsportIFv2.Areas.Identity.Pages.Profiles
{
    public class IndexModel : PageModel
    {
        private readonly TuneEsportIFv2.Data.ApplicationDbContext _context;

        [BindProperty]

            public List<Game> Games{ get; set; }

            public List<TrainingStats>TrainingStats { get; set; }
            public TrainingStats TrainingStat { get; set; }

            public List<ScoreBoard> ScoreBoard { get; set; }

            public List<Map> maps { get; set; }

            public string TuneEsportIfv2User { get; set; }

            public IScoreBoardService ScoreBoardService;
            public IGameService GameService;
            
            public IndexModel(IInfoService service, IScoreBoardService SBService, IGameService GService, TuneEsportIFv2.Data.ApplicationDbContext context)
            {
                _context = context;
                ScoreBoardService = SBService;
                GameService = GService;
        
            }

            private readonly IInfoService service;

        public IActionResult OnGet(Info info, ScoreBoard scoreBoard, Game game)
        {
            ScoreBoard = ScoreBoardService.GetAllScoreBoards(scoreBoard);
            Games = GameService.GetAllGames(game);
            TrainingStats = _context.TrainingStats.ToList();

            return Page();
        }

        public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                //UserInfo.TuneEsportIfv2User = user.Id;

            return RedirectToPage("./Index");
            }
        }
    }

