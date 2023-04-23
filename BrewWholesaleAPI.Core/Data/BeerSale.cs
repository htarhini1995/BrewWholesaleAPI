using BrewWholesaleAPI.Core.Interfaces;

namespace BrewWholesaleAPI.Core.Data;

public partial class BeerSale : IDbObject<BeerSale>
{

    #region Properties

    public int Id { get; set; }

    public int? BeerId { get; set; }

    public int? SaleId { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public virtual Beer? Beer { get; set; }

    public virtual Sale? Sale { get; set; }

    #endregion

    #region Public Methods

    public void Delete(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            BeerSale param = new BeerSale() { Id = id };
            ctx.BeerSales.Attach(param);
            ctx.BeerSales.Remove(param);
            ctx.SaveChanges();
        }
    }

    public void Delete()
    {
        this.Delete(this.Id);
    }

    public BeerSale Find(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.BeerSales.FirstOrDefault(t => t.Id == id ) ?? new BeerSale();
        }
    }

    public void Insert()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            ctx.BeerSales.Add(this);
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

    public List<BeerSale> List()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.BeerSales.ToList();
        }
    }

    #endregion

}
