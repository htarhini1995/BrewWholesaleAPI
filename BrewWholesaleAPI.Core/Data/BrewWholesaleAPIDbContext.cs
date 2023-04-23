using BrewWholesaleAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewWholesaleAPI.Core.Data
{
    public class BrewWholesaleAPIDbContext : DbContext
    {
        #region Ctor

        public BrewWholesaleAPIDbContext() { }
        public BrewWholesaleAPIDbContext(DbContextOptions<BrewWholesaleAPIDbContext> options) : base(options) { }

        #endregion

        #region Properties

        public DbSet<Brewery> Brewery { get; set; }

        #endregion

        #region Override

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(!string.IsNullOrEmpty(Configuration.DbConnectionString) ? Configuration.DbConnectionString : "Server=DESKTOP-N4P0GKT\\SQLEXPRESS;Database=BrewWholesale;MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=False;User=Hussein;Password=SA;");
            }
        } 

        #endregion
    }
}
