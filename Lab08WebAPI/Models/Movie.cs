using System;
using System.Collections.Generic;

namespace Lab08WebAPI.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string? Director { get; set; }

    public string Year { get; set; } = null!;
}
