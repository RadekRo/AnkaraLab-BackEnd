using AnkaraLab_BackEnd.WebAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public class AnkaraLabDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        public AnkaraLabDbContext(DbContextOptions<AnkaraLabDbContext> options) : base(options)
        {
        }
        
    }
}
