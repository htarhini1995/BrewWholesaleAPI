namespace BrewWholesaleAPI.Core.Data.Models;

public partial class WholesalerModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<SaleModel> Sales { get; set; } = new List<SaleModel>();

    public virtual ICollection<WholeSalerBeerModel> WholeSalerBeers { get; set; } = new List<WholeSalerBeerModel>();
}
