using Microsoft.EntityFrameworkCore;
using Sonuncuqol.Models;

namespace Sonuncuqol.Data
{
    public class SqDbContext : DbContext
    {
        public SqDbContext(DbContextOptions<SqDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SliderItem> SliderItems { get; set; }
    }
}
