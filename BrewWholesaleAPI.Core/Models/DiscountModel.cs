using System;
using System.Collections.Generic;

namespace BrewWholesaleAPI.Core.Data.Models;

public partial class DiscountModel
{
    public int Id { get; set; }

    public int? Quantity { get; set; }

    public double? Amount { get; set; }

    public virtual ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();
}
