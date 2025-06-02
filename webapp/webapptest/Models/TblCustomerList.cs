using System;
using System.Collections.Generic;

namespace webapptest.Models;

public partial class TblCustomerList
{
    public string CustomerId { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string? TaxCode { get; set; }

    public string? Address { get; set; }
}
