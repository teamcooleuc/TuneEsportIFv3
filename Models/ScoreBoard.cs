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
        [Display(Name = "Score Id")]
        public int ScoreId { get; set; }
        [Display(Name = "Kills")]
        public int Kills { get; set; }
        [Display(Name = "Death")]
        public int Death { get; set; }
        [Display(Name = "Assist")]
        public int Assist { get; set; }
        [Display(Name = "Maps name")]
        public string mapsName { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public Game games { get; set; }
        [Display(Name = "User")]
        public string TuneEsportIfv2User  { get; set; }
        [Display(Name = "Name")]

        public string FullName { get; set; }
    }
}
