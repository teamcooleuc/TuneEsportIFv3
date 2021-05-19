using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuneEsportIFv2.Models
{
    [Table("Games")]

    public class Game
    {
        [Key]
        public int gameID { get; set; }
        public string gameName { get; set; }
        public virtual ICollection<Map> maps { get; set; }
        public virtual ICollection<ScoreBoard> scoreBoards { get; set; }


    }
}
