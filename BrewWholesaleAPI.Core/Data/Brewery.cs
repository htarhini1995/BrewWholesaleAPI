using BrewWholesaleAPI.Core.Interfaces;
using BrewWholesaleAPI.Core.Models;

namespace BrewWholesaleAPI.Core.Data
{
    public partial class Brewery : IDbObject<Brewery>
    {
        #region Properties

        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool? IsDeleted { get; set; }

        #endregion

        #region Public Methods

        public void Delete(int id)
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                Brewery param = new Brewery() { Id = id };
                ctx.Brewery.Attach(param);
                ctx.Brewery.Remove(param);
                ctx.SaveChanges();
            }
        }

        public void Delete()
        {
            this.Delete(this.Id);
        }

        public Brewery Find(int id)
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                return ctx.Brewery.FirstOrDefault(t => t.Id == id) ?? new Brewery();
            }
        }

        public void Insert()
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                ctx.Brewery.Add(this);
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

        public List<Brewery> List()
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                return ctx.Brewery.ToList();
            }
        }

        #endregion

        #region Internal Methods

        internal static Brewery? Insert(BreweryModel model)
        {
            if (model != null)
            {
                var brewery = (Brewery?)model;
                brewery?.Insert();
                return brewery;
            }
            return null;
        }

        internal static Brewery? Update(BreweryModel model)
        {
            if (model != null)
            {
                var brewery = (Brewery?)model;
                brewery?.Update();
                return brewery;
            }
            return null;
        } 

        #endregion

        #region Conversion

        public static implicit operator BreweryModel?(Brewery? item)
        {
            BreweryModel? retValue = null;
            if (item != null)
            {
                retValue = new BreweryModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CreateDate = item.CreateDate,
                    ModifyDate = item.ModifyDate,
                    IsDeleted = item.IsDeleted,
                };
            }
            return retValue;
        }

        public static implicit operator Brewery?(BreweryModel? item)
        {
            Brewery? retValue= null;
            if (item != null)
            {
                retValue = new Brewery
                {
                    Id =  item.Id ?? 0,
                    Name = item.Name,
                    CreateDate = item.CreateDate,
                    ModifyDate = item.ModifyDate,
                    IsDeleted = item.IsDeleted
                };
            }
            return retValue;
        }

        #endregion
    }
}
