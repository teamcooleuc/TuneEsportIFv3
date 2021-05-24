using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TuneEsportIFv2.Models;

namespace TuneEsportIFv2.Areas.Identity.Data
{
    public class TuneEsportIfv2User : IdentityUser
    {
        //[PersonalData]
        public string Name { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string Description { get; set; }

        public string Rank { get; set; }

        public string Team { get; set; }

        public string ClubName { get; set; }

        public string Nick { get; set; }

        public string GameName { get; set; }

        public ICollection<ScoreBoard> ScoreBoards { get; set; }
        
    }
}
