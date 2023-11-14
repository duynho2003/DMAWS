using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pretest01WebApp.Models;

public partial class TblEmp
{
    [Required(ErrorMessage = "Please enter EmpId.")]
    public string EmpId { get; set; } = null!;
    [Required(ErrorMessage = "Please enter First Name.")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Please enter Last Name.")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Please enter password.")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Please enter salary.")]
    public double? Salary { get; set; }
}
