﻿using Microsoft.EntityFrameworkCore;

namespace todolistformlabreport.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Task> Tasks { get; set; }
    }
}
