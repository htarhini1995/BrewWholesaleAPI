using BrewWholesaleAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewWholesaleAPI.Core.Data
{
    public class BrewWholesaleAPIDbContext : DbContext
    {
        public BrewWholesaleAPIDbContext()
        { }
        public BrewWholesaleAPIDbContext(DbContextOptions<BrewWholesaleAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Brewery> Breweries { get; set; }
    }
}
