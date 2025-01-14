using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlogManagementApp.Models;

public partial class BlogManagementContext : DbContext
{
    public BlogManagementContext()
    {
    }

    public BlogManagementContext(DbContextOptions<BlogManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BlogContent> BlogContents { get; set; }

    public virtual DbSet<UserList> UserLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=dbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogContent>(entity =>
        {
            entity.HasKey(e => e.Bid).HasName("PK__BlogCont__C6DE0CC1C6CEC808");

            entity.ToTable("BlogContent");

            entity.Property(e => e.Bid)
                .ValueGeneratedNever()
                .HasColumnName("BId");
            entity.Property(e => e.PostDate)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SectionDescription).IsRequired();
            entity.Property(e => e.SectionHeading).IsRequired();

            entity.HasOne(d => d.CancleUser).WithMany(p => p.BlogContentCancleUsers)
                .HasForeignKey(d => d.CancleUserId)
                .HasConstraintName("FK__BlogConte__Cancl__3C69FB99");

            entity.HasOne(d => d.UploadeUser).WithMany(p => p.BlogContentUploadeUsers)
                .HasForeignKey(d => d.UploadeUserId)
                .HasConstraintName("FK__BlogConte__Uploa__3B75D760");
        });

        modelBuilder.Entity<UserList>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserList__1788CC4CCBCD97E7");

            entity.ToTable("UserList");

            entity.HasIndex(e => e.EmailAddress, "UQ__UserList__49A14740B7F959B6").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CurrentAddress)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.UserPassword).IsRequired();
            entity.Property(e => e.UserPhoto).IsRequired();
            entity.Property(e => e.UserRole)
                .IsRequired()
                .HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
