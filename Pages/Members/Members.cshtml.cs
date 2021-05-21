using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuneEsportIFv2.Areas.Identity.Data;
using TuneEsportIFv2.Models;


namespace TuneEsportIFv2.Pages.Members
{
    public class MembersModel : PageModel
    {
        public List<Info> Info { get; set; }
        public List<Game> Games { get; set; }

        public List<ScoreBoard> ScoreBoard { get; set; }

        public List<Map> maps { get; set; }

        public IActionResult OnGet(Info info, ScoreBoard scoreBoard, TuneEsportIfv2User tuneEsportIfv2User, Game game)
        {

            return Page();
        }

    }
}
