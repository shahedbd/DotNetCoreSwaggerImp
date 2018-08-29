using Microsoft.EntityFrameworkCore;

namespace Repository.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }
    }
}
