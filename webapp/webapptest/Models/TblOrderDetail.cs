using System;
using System.Collections.Generic;

namespace webapptest.Models;

public partial class TblOrderDetail
{
    public Guid RowDetailId { get; set; }

    public Guid OrderMasterId { get; set; }

    public int LineNumber { get; set; }

    public string ItemId { get; set; } = null!;

    public double Quantity { get; set; }

    public double Price { get; set; }

    public decimal Amount { get; set; }

    public virtual TblOrderMaster OrderMaster { get; set; } = null!;
}
