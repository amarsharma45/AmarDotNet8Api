
using AmarDotNet8Api_Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmarDotNet8Api_Data.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Employee> Employees => Set<Employee>();
    }
}
