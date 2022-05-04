using Microsoft.EntityFrameworkCore;
using News_Test_TaronHarutyunyan.Models;

namespace News_Test_TaronHarutyunyan
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions options) : base(options) { }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
