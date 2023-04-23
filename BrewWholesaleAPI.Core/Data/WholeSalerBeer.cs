using BrewWholesaleAPI.Core.Interfaces;

namespace BrewWholesaleAPI.Core.Data;

public partial class WholeSalerBeer : IDbObject<WholeSalerBeer>
{

    #region Properties

    public int Id { get; set; }

    public int? BeerId { get; set; }

    public int? WholesalerId { get; set; }

    public int? Quantity { get; set; }

    public virtual Beer? Beer { get; set; }

    public virtual Wholesaler? Wholesaler { get; set; }

    #endregion


    #region Public Methods

    public void Delete(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            WholeSalerBeer param = new WholeSalerBeer() { Id = id };
            ctx.WholeSalerBeers.Attach(param);
            ctx.WholeSalerBeers.Remove(param);
            ctx.SaveChanges();
        }
    }

    public void Delete()
    {
        this.Delete(this.Id);
    }

    public WholeSalerBeer Find(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.WholeSalerBeers.FirstOrDefault(t => t.Id == id) ?? new WholeSalerBeer();
        }
    }

    public void Insert()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            ctx.WholeSalerBeers.Add(this);
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

    public List<WholeSalerBeer> List()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.WholeSalerBeers.ToList();
        }
    }

    #endregion

}
