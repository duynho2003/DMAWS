using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab09Lib
{
    [Table("tbUsers")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? username { get; set; }
        public string? password { get; set; }
        public string? role { get; set; }
    }
}