using System.ComponentModel.DataAnnotations;

namespace BrewWholesaleAPI.Core.Data.Models;

public partial class WholeSalerBeerModel
{
    public int? Id { get; set; }

    [Required]
    public int? BeerId { get; set; }

    [Required]
    public int? WholesalerId { get; set; }

    [Required]
    public int? Quantity { get; set; }

    public virtual BeerModel? Beer { get; set; }

    public virtual WholesalerModel? Wholesaler { get; set; }
}
