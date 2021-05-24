using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuneEsportIFv2.Models
{
    [Table("Info")]

    public class Info
    {
        [Key]
        public int infoId { get; set; }

        public string profilPicture { get; set; }

        public string description { get; set; }

        public string rank { get; set; }

        public string team { get; set; }

        public string clubName { get; set; }
        [Required]
        public string nick { get; set; }

        internal Info Equals(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        //public User user { get; set; }

    }
}
