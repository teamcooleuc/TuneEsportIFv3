using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuneEsportIFv2.Models
{
    [Table("TrainingStats")]
    public class TrainingStats
    {
        [Key]
        public int TrainingStatId { get; set; }

        public string Records { get; set; }

        public string mapKnowledge { get; set; }

        public int Smokes { get; set; }

        public string Tactics { get; set; }

        public string EconomyKnowledge { get; set; }
        public string mapsName { get; set; }
        public DateTime Date { get; set; }

        public Map maps { get; set; }

        public Game games { get; set; }

        public string TuneEsportIfv2User { get; set; }
    }
}
