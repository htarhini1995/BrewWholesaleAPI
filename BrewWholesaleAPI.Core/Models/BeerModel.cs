using System;
using System.Collections.Generic;

namespace BrewWholesaleAPI.Core.Data.Models;

public partial class BeerModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? AlcoholAmmount { get; set; }

    public int? Price { get; set; }

    public int? BreweryId { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? ModifyDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<BeerSaleModel> BeerSales { get; set; } = new List<BeerSaleModel>();

    public virtual Brewery? Brewery { get; set; }

    public virtual ICollection<WholeSalerBeerModel> WholeSalerBeers { get; set; } = new List<WholeSalerBeerModel>();
}
