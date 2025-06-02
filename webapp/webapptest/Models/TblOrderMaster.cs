using System;
using System.Collections.Generic;

namespace webapptest.Models;

public partial class TblOrderMaster
{
    public Guid OrderMasterId { get; set; }

    public DateTime OrderDate { get; set; }

    public string OrderNo { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Mã đơn vị/chi nhánh
    /// </summary>
    public string DivSubId { get; set; } = null!;

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();
}
