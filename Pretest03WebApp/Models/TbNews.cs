using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pretest03WebApp.Models;

public partial class TbNews
{
    [Required(ErrorMessage = "Please enter NewsID.")]
    public string NewsId { get; set; } = null!;
    [Required(ErrorMessage = "Please enter NewsContent.")]
    public string? NewsContent { get; set; }
    [Required(ErrorMessage = "Please enter Date Of Publish.")]
    public string? DateOfPublish { get; set; }
}
