using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TuneEsportIFv2.Areas.Identity.Data;

namespace TuneEsportIFv2.Models
{
    [Table("ScoreBoard")]
    public class ScoreBoard
    {
        [Key]
        public int ScoreId { get; set; }

        public int Kills { get; set; }

        public int Death { get; set; }

        public int Assist { get; set; }

        public string mapsName { get; set; }

        public DateTime Date { get; set; }

        public Map maps { get; set; }

        public Game games { get; set; }

        public string TuneEsportIfv2User  { get; set; }
    }
}
