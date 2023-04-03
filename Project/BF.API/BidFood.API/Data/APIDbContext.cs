using BF.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BF.API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options) {
            
        }

        public DbSet<Employee> Employees { set; get; } 
    }
}
