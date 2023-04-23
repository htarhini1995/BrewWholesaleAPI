using BrewWholesaleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewWholesaleAPI.Data
{
    public class BrewWholesaleAPIDbContext : DbContext
    {
        public BrewWholesaleAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Brewery> Breweries { get; set; }
    }
}
