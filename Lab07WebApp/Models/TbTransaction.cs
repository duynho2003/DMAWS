using System;
using System.Collections.Generic;

namespace Lab07WebApp.Models;

public partial class TbTransaction
{
    public int Id { get; set; }

    public string? Trandate { get; set; }

    public decimal? Deposit { get; set; }

    public decimal? Withdraw { get; set; }

    public decimal? Balance { get; set; }

    public string? No { get; set; }

    public virtual TbAccount? NoNavigation { get; set; }
}
