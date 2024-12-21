using KoloroweWeb.Data.Entities;
using KoloroweWeb.Entities;
using Microsoft.EntityFrameworkCore;

namespace KoloroweWeb.Data;

public partial class KolorowewebContext : DbContext
{
    public KolorowewebContext()
    {
    }

    public KolorowewebContext(DbContextOptions<KolorowewebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Posts> Posts { get; set; }
    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<Employees> Employees { get; set; }
    public virtual DbSet<Offers> Offers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=koloroweweb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Posts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("posts");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Image)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text");
        });

        modelBuilder.Entity<Offers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("offers");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasColumnType("text");
            entity.Property(e => e.Content).HasColumnType("text");
        });

        modelBuilder.Entity<Employees>(entity =>
        {
            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Principals).HasColumnType("text");
            entity.Property(e => e.GroupRed).HasColumnType("text");
            entity.Property(e => e.GroupYellow).HasColumnType("text");
            entity.Property(e => e.GroupBlue).HasColumnType("text");
            entity.Property(e => e.GroupGreen).HasColumnType("text");
            entity.Property(e => e.Specialists).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
