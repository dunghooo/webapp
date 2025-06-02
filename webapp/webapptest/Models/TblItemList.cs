using System;
using System.Collections.Generic;

namespace webapptest.Models;

public partial class TblItemList
{
    public string ItemId { get; set; } = null!;

    public string ItemName { get; set; } = null!;

    public string? InvUnitOfMeasr { get; set; }
}
