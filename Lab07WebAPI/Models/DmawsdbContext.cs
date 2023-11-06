using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab07WebAPI.Models;

public class DmawsdbContext : DbContext
{
    public DmawsdbContext()
    {
    }

    public DmawsdbContext(DbContextOptions<DmawsdbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbTransaction> TbTransactions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=DMAWSDB;uid=sa;pwd=123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PK__tbAccoun__3213D080C3788579");

            entity.ToTable("tbAccount");

            entity.Property(e => e.No)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("no");
            entity.Property(e => e.Pincode).HasColumnName("pincode");
        });

        modelBuilder.Entity<TbTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbTransa__3213E83FE7368705");

            entity.ToTable("tbTransaction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("balance");
            entity.Property(e => e.Deposit)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("deposit");
            entity.Property(e => e.No)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("no");
            entity.Property(e => e.Trandate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("trandate");
            entity.Property(e => e.Withdraw)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("withdraw");

            entity.HasOne(d => d.NoNavigation).WithMany(p => p.TbTransactions)
                .HasForeignKey(d => d.No)
                .HasConstraintName("FK__tbTransactio__no__0D7A0286");
        });

        // OnModelCreatingPartial(modelBuilder);
    }

    // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
