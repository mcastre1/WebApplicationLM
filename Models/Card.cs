using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebApplicationLM.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("ColumnId")]
        public virtual Column Column { get; set; }

        public string Details { get; set; }

        [Required] //set default 
        public string Priority { get; set; }

    }
}
