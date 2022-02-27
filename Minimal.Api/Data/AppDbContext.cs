using Microsoft.EntityFrameworkCore;
using Minimal.Api.Models;

namespace Minimal.Api.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MNIMAL_API;User=sa;Password=Secret@1234");
    }
}
