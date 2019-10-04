using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assignment1.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }

        [ForeignKey("Guild")]
        public int GuildID { get; set; }

        public string CharacterName { get; set; }

        public string Race { get; set; }

        public string Class { get; set; }
    }
}
