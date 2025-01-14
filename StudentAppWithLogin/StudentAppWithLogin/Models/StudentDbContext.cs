using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentAppWithLogin.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<UserList> UserLists { get; set; }


    //name=con1 reads from here
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=Con1");

    //model class when crates it need all data so it uses this
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            //it has this pk name ....it make 
            entity.HasKey(e => e.Id).HasName("PK__student__3214EC07EFCD05E7");

            //table of student
            entity.ToTable("student");

            entity.Property(e => e.Address).HasMaxLength(40);
            entity.Property(e => e.Fee).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EntryUser).WithMany(p => p.Students)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__student__EntryUs__60A75C0F");
        });

        modelBuilder.Entity<UserList>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserList__1788CC4C39F50040");

            entity.ToTable("UserList");

            entity.HasIndex(e => e.LoginId, "UQ__UserList__4DDA2819BE4C0FF6").IsUnique();

            entity.Property(e => e.LoginId).HasMaxLength(50);
            entity.Property(e => e.LoginPassword).HasMaxLength(50);
            entity.Property(e => e.LoginStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
