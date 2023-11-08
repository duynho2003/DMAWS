using System;
using System.Collections.Generic;

namespace Lab08WebAPI.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CustomerPhone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
