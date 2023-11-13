using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab10WebAPI.Models;

public partial class DmawsdbContext : DbContext
{
    public DmawsdbContext()
    {
    }

    public DmawsdbContext(DbContextOptions<DmawsdbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=DMAWSDB;uid=sa;pwd=123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Employee__357D4CF8FC0FFDA5");

            entity.ToTable("Employee");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Roles)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("roles");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("salary");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
