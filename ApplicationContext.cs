using Microsoft.EntityFrameworkCore;
using template_csharp_reviews_site.Models;

namespace template_csharp_reviews_site
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        const string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb; Database=ReviewsSite2; Trusted_connection=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Brand = "Samsung",
                Model = "Galaxy",
                OSVer = "Android 10",
                Processor = "Snap Dragon",
                RamSize = "256GB",
                Storage = "512GB",
                Price = 800.00,
                Picture = "https://th.bing.com/th/id/OIP.KaKM93VZeh0ZQH0ylnub2gHaHa?pid=ImgDet&rs=1",
                ReleaseDate = System.DateTime.Now
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Brand = "Apple",
                Model = "iPhone 13 Pro Max",
                OSVer = "iOS",
                Price = 1099.00,
                Processor = "Snap Dragon",
                RamSize = "256GB",
                Storage = "512GB",
                Picture = "https://th.bing.com/th/id/R.708c4252d828ae9a7f2eb797f7577b30?rik=4b1OYH%2bB6nrH2g&pid=ImgRaw&r=0",
                ReleaseDate = System.DateTime.Now
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Brand = "Motorola",
                Model = "Razr",
                OSVer = "Android 9",
                Price = 499.00,
                Processor = "Snap Dragon",
                RamSize = "256GB",
                Storage = "512GB",
                Picture = "https://th.bing.com/th/id/OIP.oMxlQYNUc6msuFWHGQOglgHaHc?pid=ImgDet&rs=1",
                ReleaseDate = System.DateTime.Now
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Brand = "GooglePhone",
                Model = "Pixel 6 Pro",
                OSVer = "Android 12",
                Price = 599.00,
                Processor = "Snap Dragon",
                RamSize = "256GB",
                Storage = "512GB",
                Picture = "https://touchit.sk/wp-content/uploads/2021/05/google_pixel_6_6_pro_duo_nowat.jpg",
                ReleaseDate = System.DateTime.Now
            });

            modelBuilder.Entity<Review>().HasData(new Review
            {
                Id = 1,
                ReviewDate = System.DateTime.Now,
                Title = "Great.",
                UserName = "Lisa",
                Content = "I love it.",
                ProductId = 1,
                Rating = 5
            });
            modelBuilder.Entity<Review>().HasData(new Review
            {
                Id = 2,
                ReviewDate = System.DateTime.Now,
                Title = "Great.",
                UserName = "Norm",
                Content = "I love it.",
                ProductId = 2,
                Rating = 5
            });
            modelBuilder.Entity<Review>().HasData(new Review
            {
                Id = 3,
                ReviewDate = System.DateTime.Now,
                Title = "Great.",
                UserName = "Chaz",
                Content = "I love it.",
                ProductId = 3,
                Rating = 5
            });
            modelBuilder.Entity<Review>().HasData(new Review
            {
                Id = 5,
                ReviewDate = System.DateTime.Now,
                Title = "Great.",
                UserName = "Donna",
                Content = "I love it.",
                ProductId = 1,
                Rating = 5
            });
        }
    }
}
