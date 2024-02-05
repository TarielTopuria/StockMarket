using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext(DbContextOptions op) : DbContext(op)
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Stocks table
            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, Symbol = "TSLA", CompanyName = "Tesla", Purchase = 100.00M, LastDiv = 2.0M, Industry = "Automotive", MarketCap = 123123 },
                new Stock { Id = 2, Symbol = "MSFT", CompanyName = "Microsoft", Purchase = 100.00M, LastDiv = 1.0M, Industry = "Technology", MarketCap = 323212 }
            );

            // Seed data for Comments table
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, Title = "First Comment Title", Content = "Test Content for first comment", CreationTime = DateTime.Now, StockId = 1},
                new Comment { Id = 2, Title = "Second Comment Title", Content = "Test Content for second comment", CreationTime = DateTime.Now, StockId = 2 }
            );
        }
    }
}
