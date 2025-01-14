using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeFirstApproachExample.Models
{
    public class MyDbcontext : DbContext
    {
        private readonly IConfiguration _config;

        public MyDbcontext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Con1"));
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
