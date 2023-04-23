using System;
using System.Collections.Generic;

namespace BrewWholesaleAPI.Core.Data.Models;

public partial class SaleModel
{
    public int Id { get; set; }

    public int? WholesalerId { get; set; }

    public int? DiscountId { get; set; }

    public double? TotalPrice { get; set; }

    public virtual ICollection<BeerSaleModel> BeerSales { get; set; } = new List<BeerSaleModel>();

    public virtual DiscountModel? Discount { get; set; }

    public virtual WholesalerModel? Wholesaler { get; set; }
}
