using AnkaraLab_BackEnd.WebAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public class AnkaraLabDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        public AnkaraLabDbContext(DbContextOptions<AnkaraLabDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData
            (
                new Category
                {
                    Name = "Odbitka",
                    Description = "Odbitka fotograficzna z procesu fotochemicznego"
                },
                new Category
                {
                    Name = "Wydruk wielkoformatowy",
                    Description = "Wydruk atramentowy wysokiej jakości"
                }
            );

            modelBuilder.Entity<Product>().HasData
            (
                new Product
                {
                    Subcategory = "10x15",
                    Size = "10x15 cm",
                    Description = "",
                    Price = 0.90,
                    Deadline = 1,
                    IsAvaliable = true,
                    PhotoHeight = 102,
                    PhotoWidth = 152,
                    CategoryId = 1
                },
                new Product
                {
                    Subcategory = "15x21",
                    Size = "15x21 cm",
                    Description = "",
                    Price = 2.00,
                    Deadline = 1,
                    IsAvaliable = true,
                    PhotoHeight = 152,
                    PhotoWidth = 210,
                    CategoryId = 1
                }
            );
        }
        
    }
}
