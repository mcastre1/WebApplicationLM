using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationLM.Models
{
    public class Workspace
    {
        [Key]
        public int WorkspaceId { get; set; }

        [Required]
        public string Title { get; set; }

        //[ForeignKey("UserId")]
        //public virtual User User { get; set; }


    }
}
