using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationLM.Models
{
    public class Column
    {
        [Key]
        public int ColumnId { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("WorkspaceId")]
        public virtual Workspace Workspace { get; set; }
    }
}
