using BrewWholesaleAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewWholesaleAPI.Core.Data
{
    public partial class BrewWholesaleContext : DbContext
    { 
        public BrewWholesaleContext()
        {
        }

        public BrewWholesaleContext(DbContextOptions<BrewWholesaleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beer> Beers { get; set; }

        public virtual DbSet<BeerSale> BeerSales { get; set; }

        public virtual DbSet<Brewery> Breweries { get; set; }

        public virtual DbSet<Discount> Discounts { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<WholeSalerBeer> WholeSalerBeers { get; set; }

        public virtual DbSet<Wholesaler> Wholesalers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=DESKTOP-N4P0GKT\\SQLEXPRESS;Database=BrewWholesale;MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=False;User=Hussein;Password=SA;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>(entity =>
            {
                entity.ToTable("Beer");

                entity.Property(e => e.CreateDate).HasColumnType("date");
                entity.Property(e => e.ModifyDate)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brewery).WithMany(p => p.Beers)
                    .HasForeignKey(d => d.BreweryId)
                    .HasConstraintName("FK_Beer_Brewery");
            });

            modelBuilder.Entity<BeerSale>(entity =>
            {
                entity.ToTable("BeerSale");

                entity.HasOne(d => d.Beer).WithMany(p => p.BeerSales)
                    .HasForeignKey(d => d.BeerId)
                    .HasConstraintName("FK_BeerSale_Beer");

                entity.HasOne(d => d.Sale).WithMany(p => p.BeerSales)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("FK_BeerSale_Sale");
            });

            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.ToTable("Brewery");

                entity.Property(e => e.CreateDate).HasColumnType("date");
                entity.Property(e => e.ModifyDate).HasColumnType("date");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.Exception)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.FullExeption)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Message)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Discount).WithMany(p => p.Sales)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_Sale_Discount");

                entity.HasOne(d => d.Wholesaler).WithMany(p => p.Sales)
                    .HasForeignKey(d => d.WholesalerId)
                    .HasConstraintName("FK_Sale_Wholesaler");
            });

            modelBuilder.Entity<WholeSalerBeer>(entity =>
            {
                entity.ToTable("WholeSalerBeer");

                entity.HasOne(d => d.Beer).WithMany(p => p.WholeSalerBeers)
                    .HasForeignKey(d => d.BeerId)
                    .HasConstraintName("FK_WholeSalerBeer_Beer");

                entity.HasOne(d => d.Wholesaler).WithMany(p => p.WholeSalerBeers)
                    .HasForeignKey(d => d.WholesalerId)
                    .HasConstraintName("FK_WholeSalerBeer_Wholesaler");
            });

            modelBuilder.Entity<Wholesaler>(entity =>
            {
                entity.ToTable("Wholesaler");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CreateDate).HasColumnType("date");
                entity.Property(e => e.ModifyDate).HasColumnType("date");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
