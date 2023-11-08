using System;
using System.Collections.Generic;

namespace Lab08WebAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual Category? Category { get; set; }
}
