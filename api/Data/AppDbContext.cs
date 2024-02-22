using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext(DbContextOptions op) : IdentityDbContext<AppUser>(op)
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Stocks
            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, Symbol = "AAPL", CompanyName = "Apple Inc.", Purchase = 150.00m, LastDiv = 0.82m, Industry = "Technology", MarketCap = 2000000000000 },
                new Stock { Id = 2, Symbol = "MSFT", CompanyName = "Microsoft Corporation", Purchase = 250.00m, LastDiv = 1.24m, Industry = "Technology", MarketCap = 1800000000000 },
                new Stock { Id = 3, Symbol = "AMZN", CompanyName = "Amazon.com, Inc.", Purchase = 3100.00m, LastDiv = 0.00m, Industry = "Retail", MarketCap = 1600000000000 },
                new Stock { Id = 4, Symbol = "GOOGL", CompanyName = "Alphabet Inc.", Purchase = 2800.00m, LastDiv = 0.00m, Industry = "Technology", MarketCap = 1500000000000 },
                new Stock { Id = 5, Symbol = "FB", CompanyName = "Meta Platforms, Inc.", Purchase = 325.00m, LastDiv = 0.00m, Industry = "Technology", MarketCap = 800000000000 },
                new Stock { Id = 6, Symbol = "TSLA", CompanyName = "Tesla, Inc.", Purchase = 900.00m, LastDiv = 0.00m, Industry = "Automotive", MarketCap = 600000000000 },
                new Stock { Id = 7, Symbol = "BRK.A", CompanyName = "Berkshire Hathaway Inc.", Purchase = 350000.00m, LastDiv = 0.00m, Industry = "Conglomerate", MarketCap = 550000000000 },
                new Stock { Id = 8, Symbol = "V", CompanyName = "Visa Inc.", Purchase = 220.00m, LastDiv = 1.28m, Industry = "Financial Services", MarketCap = 450000000000 },
                new Stock { Id = 9, Symbol = "JNJ", CompanyName = "Johnson & Johnson", Purchase = 165.00m, LastDiv = 3.80m, Industry = "Healthcare", MarketCap = 400000000000 },
                new Stock { Id = 10, Symbol = "WMT", CompanyName = "Walmart Inc.", Purchase = 140.00m, LastDiv = 2.16m, Industry = "Retail", MarketCap = 350000000000 },
                new Stock { Id = 11, Symbol = "NVDA", CompanyName = "NVIDIA Corporation", Purchase = 500.00m, LastDiv = 0.16m, Industry = "Technology", MarketCap = 300000000000 }
            );


            // Seed data for Comments
            modelBuilder.Entity<Comment>().HasData(
                new Comment { Id = 1, Title = "Innovative", Content = "Leading the tech industry.", CreationTime = DateTime.Now, StockId = 1 },
                new Comment { Id = 2, Title = "Solid Performance", Content = "Consistent growth over the years.", CreationTime = DateTime.Now, StockId = 2 },
                new Comment { Id = 3, Title = "Expansive Reach", Content = "Dominating the retail space.", CreationTime = DateTime.Now, StockId = 3 },
                new Comment { Id = 4, Title = "Tech Giant", Content = "Continuously innovating.", CreationTime = DateTime.Now, StockId = 4 },
                new Comment { Id = 5, Title = "Social Impact", Content = "Changing how we connect.", CreationTime = DateTime.Now, StockId = 5 },
                new Comment { Id = 6, Title = "Revolutionary", Content = "Transforming the auto industry.", CreationTime = DateTime.Now, StockId = 6 },
                new Comment { Id = 7, Title = "Stable Investment", Content = "A diverse portfolio.", CreationTime = DateTime.Now, StockId = 7 },
                new Comment { Id = 8, Title = "Financial Leader", Content = "A key player in global finance.", CreationTime = DateTime.Now, StockId = 8 },
                new Comment { Id = 9, Title = "Trusted Brand", Content = "Reliable and consistent.", CreationTime = DateTime.Now, StockId = 9 },
                new Comment { Id = 10, Title = "Retail Powerhouse", Content = "A cornerstone of retail.", CreationTime = DateTime.Now, StockId = 10 },
                new Comment { Id = 11, Title = "Tech Innovator", Content = "Leading in graphics technology.", CreationTime = DateTime.Now, StockId = 11 }
            );

            // Seed data for user roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Name = "Operator", NormalizedName = "OPERATOR" },
                new IdentityRole { Name = "Client", NormalizedName = "CLIENT" }
            );
        }
    }
}
