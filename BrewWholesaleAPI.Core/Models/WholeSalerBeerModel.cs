namespace BrewWholesaleAPI.Core.Data.Models;

public partial class WholeSalerBeerModel
{
    public int Id { get; set; }

    public int? BeerId { get; set; }

    public int? WholesalerId { get; set; }

    public int? Quantity { get; set; }

    public virtual BeerModel? Beer { get; set; }

    public virtual WholesalerModel? Wholesaler { get; set; }
}
