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
        [Display(Name = "Map Id")]
        public int mapsId { get; set; }
        [Display(Name = "Map name")]
        [Required]
        public string mapsName { get; set; }
        
        [Display(Name = "Game Name")]
        public string gameName { get; set; }
        public Game Games { get; set; }
        //public virtual ICollection<ScoreBoard> ScoreBoards { get; set; }

       
    }
}
