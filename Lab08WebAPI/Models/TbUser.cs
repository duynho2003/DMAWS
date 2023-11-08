using System;
using System.Collections.Generic;

namespace Lab08WebAPI.Models;

public partial class TbUser
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool? Role { get; set; }
}
