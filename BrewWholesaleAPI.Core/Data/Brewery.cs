using BrewWholesaleAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewWholesaleAPI.Core.Data
{
    public partial class Brewery :IDbObject<Brewery>
    {
        #region Properties

        public Guid Id { get; set; }
        public string? Name { get; set; } 

        #endregion


        #region Public Methods

        public void Delete(Guid id)
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                Brewery param = new Brewery() { Id = id };
                ctx.Breweries.Attach(param);
                ctx.Breweries.Remove(param);
                ctx.SaveChanges();
            }
        }

        public void Delete()
        {
            this.Delete(this.Id);
        }

        public Brewery Find(Guid id)
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                return ctx.Breweries.FirstOrDefault(t => t.Id == id) ?? new Brewery();
            }
        }

        public void Insert()
        {
            using (var ctx = Configuration.OpenContext(false))
            {
                ctx.Breweries.Add(this);
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
                return ctx.Breweries.ToList();
            }
        } 

        #endregion
    }
}
