using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
         [BindProperty]

            public List<Info> Info { get; set; }
            public List<Game> Games{ get; set; }

            public List<ScoreBoard> ScoreBoard { get; set; }

            public List<Map> maps { get; set; }

            public List<Game> games { get; set; }

            public IInfoService InfoService;
            public IScoreBoardService ScoreBoardService;
            public IGameService GameService;

            public IndexModel(IInfoService service, IScoreBoardService SBService, IGameService GService)
            {
                InfoService = service;
                ScoreBoardService = SBService;
                GameService = GService;
            }

            private readonly IInfoService service;

        public IActionResult OnGet(Info info, ScoreBoard scoreBoard, TuneEsportIfv2User tuneEsportIfv2User, Game game)
        {
            Info = InfoService.GetAllInfo(info);
            ScoreBoard = ScoreBoardService.GetAllScoreBoards(scoreBoard);
            Games = GameService.GetAllGames(game);

            return Page();
        }

        public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                return RedirectToPage("./Index");
            }
        }
    }

