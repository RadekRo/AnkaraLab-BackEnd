using AnkaraLab_BackEnd.WebAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AnkaraLab_BackEnd.WebAPI.Infrastructure.PaymentMethodEnum;
using static AnkaraLab_BackEnd.WebAPI.Infrastructure.PaymentStatusEnum;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public class AnkaraLabDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Faq> Faqs => Set<Faq>();
        public DbSet<BasketItems> BasketItems => Set<BasketItems>();


        public AnkaraLabDbContext(DbContextOptions<AnkaraLabDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Odbitka",
                    Description = "Odbitka fotograficzna z procesu fotochemicznego"
                },
                new Category
                {
                    Id = 2,
                    Name = "Wydruk wielkoformatowy",
                    Description = "Wydruk atramentowy wysokiej jakości"
                },
                new Category
                {
                    Id = 3,
                    Name = "Gadżety",
                    Description = "Gadżety z plików cyfrowych"
                }
            );

            modelBuilder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 1,
                    Size = "10x15",
                    Description = "Odbitka fotograficzna w formaciw 10x15",
                    Price = 0.90,
                    Deadline = 1,
                    IsAvaliable = true,
                    PhotoHeight = 102,
                    PhotoWidth = 152,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Size = "15x21",
                    Description = "Odbitka fotograficzna w formacie 15x21",
                    Price = 2.00,
                    Deadline = 1,
                    IsAvaliable = true,
                    PhotoHeight = 152,
                    PhotoWidth = 210,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Size = "10x10",
                    Description = "Fotokula śnieżna",
                    Price = 25.00,
                    Deadline = 3,
                    IsAvaliable = true,
                    PhotoHeight = 100,
                    PhotoWidth = 100,
                    CategoryId = 3
                }
            );

            modelBuilder.Entity<Order>().HasData
            (
            new Order
                {
                    Id = 1,
                    DeliveryAddress = "Polna 10",
                    InvoiceAddress = "Rolnicza 12",
                    PaymentMethod = "Blik",
                    PaymentStatus = "Pending"
                    
        },
                new Order
                {
                    Id = 2,
                    DeliveryAddress = "Stara 210",
                    InvoiceAddress = "Woronicza 121",
                    PaymentMethod = "PayU",
                    PaymentStatus = "Failed"
                }
            );
        }
        
    }
}
