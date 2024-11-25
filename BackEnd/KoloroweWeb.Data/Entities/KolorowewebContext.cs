using System;
using System.Collections.Generic;
using KoloroweWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoloroweWeb.Entities;

public partial class KolorowewebContext : DbContext
{
    public KolorowewebContext()
    {
    }

    public KolorowewebContext(DbContextOptions<KolorowewebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Userpost> Userposts { get; set; }
    public virtual DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=koloroweweb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Userpost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("userpost");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
