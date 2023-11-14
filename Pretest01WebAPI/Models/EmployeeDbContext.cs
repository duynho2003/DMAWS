using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pretest01WebAPI.Models;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEmp> TblEmps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=EmployeeDB;uid=sa;pwd=123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEmp>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__tblEmp__AF2DBA79625DB54B");

            entity.ToTable("tblEmp");

            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EmpID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
