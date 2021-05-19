using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Models;
using TuneEsportIFv2.Services.Interfaces;

namespace TuneEsportIFv2.Areas.Identity.Pages.Profiles
{
    public class IndexModel : PageModel
    {
         [BindProperty]

            public List<Info> Info { get; set; }

            public List<ScoreBoard> ScoreBoard { get; set; }


            public IInfoService InfoService;
            public IScoreBoardService ScoreBoardService;

            public IndexModel(IInfoService service, IScoreBoardService SBService)
            {
                InfoService = service;
                ScoreBoardService = SBService;
            }

            private readonly IInfoService service;

        public IActionResult OnGet(Info info, ScoreBoard scoreBoard, TuneEsportIfv2User tuneEsportIfv2User)
        {
            Info = InfoService.GetAllInfo(info);
            ScoreBoard = ScoreBoardService.GetAllScoreBoards(scoreBoard);

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

