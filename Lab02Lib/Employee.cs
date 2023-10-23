using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab02Lib
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? id {  get; set; }
        [Required]
        public string? name {  get; set; }
        public string? phone {  get; set; }
    }
}