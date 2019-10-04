using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Guild
    {
        [Key]
        public int GuildID { get; set; }

        public string GuildName { get; set; }

        public string GuildTag { get; set; }

        public bool GuildHall { get; set; }

        public int Level { get; set; }
    }
}
