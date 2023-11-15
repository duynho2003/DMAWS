using System;
using System.Collections.Generic;

namespace Student1408049WebAPI.Models;

public partial class Laptop
{
    public int LaptopId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public bool? Fingerprint { get; set; }
}
