using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuneEsportIFv2.Models
{
    [Table("Maps")]

    public class Map
    {

        [Key]
        public int mapsId { get; set; }
        public string mapsName { get; set; }
        public string gameName { get; set; }
        public Game games { get; set; }


        public virtual ICollection<ScoreBoard> ScoreBoards { get; set; }

       
    }
}
