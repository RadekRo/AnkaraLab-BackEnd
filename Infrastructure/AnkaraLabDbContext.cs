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
        public DbSet<LoyaltyProgram> LoyaltyPrograms => Set<LoyaltyProgram>();
        public DbSet<Basket> Baskets => Set<Basket>();


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

            modelBuilder.Entity<Faq>().HasData
            (
            new Faq
                {
                    Id = 11,
                    Question = "Jakie formaty plików są odczytywane prez laba?",
                    Answer = "dlab-2 (maszyna znajdująca się w posiadaniu AnkaraLab.com) naświetla zdjęcia z plików zapisanych w formatach .jpg, .tif, .bmp, .psd, których wielkość nie przekracza 100 Mb (przed kompresją)."
                },
            new Faq
                {
                    Id = 22,
                    Question = "Czy można wywołać zdjęcia z plików prosto z aparatu?",
                    Answer = "Tak, nie ma konieczności przerabiania plików, jeśli aparat zapisuje je w formacie obsługiwanym przez maszynę (patrz, pkt.1). Uwaga! Maszyna nie akceptuje plików RAW. Aby uzyskać najlepsze efekty zdjęcia można skadrować, znając dokładne formaty odbitek i ew. obrobić kolorystycznie, pamiętając o kalibracji monitora."
                }
            );

            modelBuilder.Entity<Basket>().HasData
            (
                new Basket
                {
                    Id = 1,
                    ClientId = 1,
                    ProductId = 1,
                    Quantity = 1,
                    OrderId = 1
                },
                new Basket
                {
                    Id = 2,
                    ClientId = 2,
                    ProductId = 2,
                    Quantity = 2,
                    OrderId = 2
                }
            );
        } 
    }
}
