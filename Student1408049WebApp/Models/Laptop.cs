using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student1408049WebApp.Models;

public partial class Laptop
{
    public int LaptopId { get; set; }
    [Required(ErrorMessage ="Please enter name Laptop!")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Please enter name Price!")]
    public decimal? Price { get; set; }
    [Required(ErrorMessage = "Please set Fingerprint!")]
    public bool? Fingerprint { get; set; }
}
