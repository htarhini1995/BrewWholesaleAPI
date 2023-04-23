using BrewWholesaleAPI.Core.Interfaces;

namespace BrewWholesaleAPI.Core.Data;

public partial class Beer : IDbObject<Beer>
{

    #region Properties

    public int Id { get; set; }

    public string? Name { get; set; }

    public double? AlcoholAmmount { get; set; }

    public int? Price { get; set; }

    public int? BreweryId { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? ModifyDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<BeerSale> BeerSales { get; set; } = new List<BeerSale>();

    public virtual Brewery? Brewery { get; set; }

    public virtual ICollection<WholeSalerBeer> WholeSalerBeers { get; set; } = new List<WholeSalerBeer>();

    #endregion

    #region Public Methods

    public void Delete(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            Beer param = new Beer() { Id = id };
            ctx.Beers.Attach(param);
            ctx.Beers.Remove(param);
            ctx.SaveChanges();
        }
    }

    public void Delete()
    {
        this.Delete(this.Id);
    }

    public Beer Find(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.Beers.FirstOrDefault(t => t.Id == id && ( IsDeleted ?? false )) ?? new Beer();
        }
    }

    public void Insert()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            ctx.Beers.Add(this);
            ctx.SaveChanges();
        }
    }

    public void Update()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            ctx.Entry(this).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
        }
    }

    public List<Beer> List()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.Beers.Where(t =>(IsDeleted ?? false)).ToList();
        }
    }

    #endregion

}
