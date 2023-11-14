using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pretest03WebAPI.Models;

public partial class NewsDbContext : DbContext
{
    public NewsDbContext()
    {
    }

    public NewsDbContext(DbContextOptions<NewsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbNews> TbNews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=LAPTOP-PH1AFEK8\\SQLEXPRESS;database=NewsDB;uid=sa;pwd=123;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbNews>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__tbNews__954EBDF384A3A509");

            entity.ToTable("tbNews");

            entity.Property(e => e.NewsId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DateOfPublish)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NewsContent)
                .HasMaxLength(356)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
