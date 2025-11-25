using Microsoft.EntityFrameworkCore;
using trabajo_final_api_rest.model;
namespace trabajo_final_api_rest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Producto> productos { get; set; }
    }
}
