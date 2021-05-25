using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuneEsportIFv2.Models
{
    [Table("TrainingStats")]
    public class TrainingStat
    {
        [Key]
        [Display(Name = "Trainings stats Id")]
        public int TrainingStatId { get; set; }
        [Display(Name = "Map knowledge")]
        public string mapKnowledge { get; set; }
        [Display(Name = "Smokes")]
        public int Smokes { get; set; }
        [Display(Name = "Tactics")]
        public string Tactics { get; set; }
        [Display(Name = "Economy knowledge")]
        public string EconomyKnowledge { get; set; }
        [Display(Name = "Map name")]
        public string mapsName { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        public Game games { get; set; }

        [Display(Name = "User")]
        public string TuneEsportIfv2User { get; set; }
    }
}
