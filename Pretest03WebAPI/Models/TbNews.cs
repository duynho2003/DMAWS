using System;
using System.Collections.Generic;

namespace Pretest03WebAPI.Models;

public partial class TbNews
{
    public string NewsId { get; set; } = null!;

    public string? NewsContent { get; set; }

    public string? DateOfPublish { get; set; }
}
