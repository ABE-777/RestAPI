using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Paste")]
    public  class Paste
    {
        [Key]
        public int PasteId { get; set; }

        [Column("Identifier", TypeName = "varchar")]
        [MaxLength(20)]
        [Required]
        public string Identifier { get; set; }

        [Column("Content", TypeName = "ntext")]
        public string Content { get; set; }

        [Column("CreateDate", TypeName = "Date")]
        public DateTime CreateDate { get; set; }

        [Column("AccessDate", TypeName = "DateTime2")]
        public DateTime AccessDate { get; set; }
    }
}
