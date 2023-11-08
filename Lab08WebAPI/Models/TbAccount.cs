using System;
using System.Collections.Generic;

namespace Lab08WebAPI.Models;

public partial class TbAccount
{
    public string No { get; set; } = null!;

    public int? Pincode { get; set; }

    public virtual ICollection<TbTransaction> TbTransactions { get; set; } = new List<TbTransaction>();
}
