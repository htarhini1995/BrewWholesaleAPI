using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrewWholesaleAPI.Core.Data.Models;

public partial class SaleModel
{
    public int? Id { get; set; }

    [Required]
    public int? WholesalerId { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? TotalDiscountedPrice { get; set; }

    public bool IsQuote { get; set; }

    public string? Summery { get; set; }

    public virtual ICollection<BeerSaleModel> BeerSales { get; set; } = new List<BeerSaleModel>();

}
