using System;
using System.Collections.Generic;

namespace Pretest01WebAPI.Models;

public partial class TblEmp
{
    public string EmpId { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

    public double? Salary { get; set; }
}
