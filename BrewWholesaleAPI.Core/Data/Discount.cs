using BrewWholesaleAPI.Core.Interfaces;

namespace BrewWholesaleAPI.Core.Data;

public partial class Discount : IDbObject<Discount>
{

  #region Properties

        public int Id { get; set; }

        public int? Quantity { get; set; }

        public double? Amount { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

        #endregion
 
  #region Public Methods

        public void Delete(int id)
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                Discount param = new Discount() { Id = id };
                ctx.Discounts.Attach(param);
                ctx.Discounts.Remove(param);
                ctx.SaveChanges();
            }
        }

        public void Delete()
        {
            this.Delete(this.Id);
        }

        public Discount Find(int id)
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                return ctx.Discounts.FirstOrDefault(t => t.Id == id) ?? new Discount();
            }
        }

        public void Insert()
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                ctx.Discounts.Add(this);
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

        public List<Discount> List()
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                return ctx.Discounts.ToList();
            }
        }

        #endregion

}


