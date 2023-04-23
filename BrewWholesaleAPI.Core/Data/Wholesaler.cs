using BrewWholesaleAPI.Core.Interfaces;

namespace BrewWholesaleAPI.Core.Data;

public partial class Wholesaler : IDbObject<Wholesaler>
{

    #region Properties
    
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifyDate { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<WholeSalerBeer> WholeSalerBeers { get; set; } = new List<WholeSalerBeer>();

    #endregion

    #region Public Methods

    public void Delete(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            Wholesaler param = new Wholesaler() { Id = id };
            ctx.Wholesalers.Attach(param);
            ctx.Wholesalers.Remove(param);
            ctx.SaveChanges();
        }
    }

    public void Delete()
    {
        this.Delete(this.Id);
    }

    public Wholesaler Find(int id)
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.Wholesalers.FirstOrDefault(t => t.Id == id && (IsDeleted ?? false)) ?? new Wholesaler();
        }
    }

    public void Insert()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            ctx.Wholesalers.Add(this);
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

    public List<Wholesaler> List()
    {
        using (var ctx = Configuration.OpenContext(false))
        {
            return ctx.Wholesalers.Where(t => (IsDeleted ?? false)).ToList();
        }
    }

    #endregion

}
