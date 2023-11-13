using System;
using System.Collections.Generic;

namespace Lab10WebAPI.Models;

public partial class Employee
{
    public string Code { get; set; } = null!;

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public decimal? Salary { get; set; }

    public string? Roles { get; set; }
}
