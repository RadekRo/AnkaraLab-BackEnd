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
                    Size = "15x21",
                    Description = "Odbitka fotograficzna w formacie 15x21",
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
