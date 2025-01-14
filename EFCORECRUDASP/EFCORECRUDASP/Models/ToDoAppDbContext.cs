using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCORECRUDASP.Models;

public partial class ToDoAppDbContext : DbContext
{
    public ToDoAppDbContext()
    {
    }

    public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoList> TodoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=MyCon");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.HasKey(e => e.Sn).HasName("PK__TodoList__32151C445BF1F416");

            entity.ToTable("TodoList");

            entity.Property(e => e.Sn).ValueGeneratedNever();
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.EntryDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TaskName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
