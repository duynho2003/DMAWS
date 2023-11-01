using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab06Lib
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {  get; set; }
        [Required]
        public string? title { get; set; }
        [Required]
        public string? genre { get; set; }
        public string? director { get; set; }
        [Required]
        [Range(2000, 2024, ErrorMessage ="Release year from 2000 to 2024")]
        public string? year { get; set; }
    }
}