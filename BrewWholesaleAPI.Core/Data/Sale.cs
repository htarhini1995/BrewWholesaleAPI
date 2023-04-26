using BrewWholesaleAPI.Core.Interfaces;

namespace BrewWholesaleAPI.Core.Data;

public partial class Sale : IDbObject<Sale>
{

    #region Properties

    public int Id { get; set; }

    public int? WholesalerId { get; set; }

    public int? DiscountId { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? TotalDiscountedPrice { get; set; }

    public virtual ICollection<BeerSale> BeerSales { get; set; } = new List<BeerSale>();

    public virtual Discount? Discount { get; set; }

    public virtual Wholesaler? Wholesaler { get; set; }

    #endregion


    #region Public Methods

    public void Delete(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            Sale param = new Sale() { Id = id };
            ctx.Sales.Attach(param);
            ctx.Sales.Remove(param);
            ctx.SaveChanges();
        }
    }

    public void Delete()
    {
        this.Delete(this.Id);
    }

    public Sale Find(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.Sales.FirstOrDefault(t => t.Id == id) ?? new Sale();
        }
    }

    public void Insert()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            ctx.Sales.Add(this);
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

    public List<Sale> List()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.Sales.ToList();
        }
    }

    #endregion

}
