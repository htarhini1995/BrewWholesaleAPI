using System;
using System.Collections.Generic;

namespace BrewWholesaleAPI.Core.Data.Models;

public partial class BeerSaleModel
{
    public int Id { get; set; }

    public int? BeerId { get; set; }

    public int? SaleId { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public virtual BeerModel? Beer { get; set; }

    public virtual SaleModel? Sale { get; set; }
}
