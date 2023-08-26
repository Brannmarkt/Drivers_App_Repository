using Microsoft.EntityFrameworkCore;
using WebApi_RepositoryPattern.Models;

namespace WebApi_RepositoryPattern.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {
            
        }

        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Driver> Drivers { get; set; }
    }
}
