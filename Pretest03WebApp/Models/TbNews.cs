using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pretest03WebApp.Models;

public partial class TbNews
{
    [Required]
    public string NewsId { get; set; } = null!;
    [Required]
    public string? NewsContent { get; set; }
    [Required]
    public string? DateOfPublish { get; set; }
}
