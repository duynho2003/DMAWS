using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab04
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(60)]
        public string? CustomerName { get; set; }

        [Required]
        [StringLength(150)]
        public string? CustomerAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string? CustomerPhone { get; set;}

        public List<Orders>? Orders { get; set; }    
    }
}