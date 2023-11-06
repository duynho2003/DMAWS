using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07Lib
{
    [Table("tbTransaction")]
    public class Transactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string? trandate { get; set; }
        public decimal deposit { get; set; }
        public decimal withdraw { get; set; }
        public decimal balance { get; set; }
        public string? no { get; set; } //FK
    }
}
