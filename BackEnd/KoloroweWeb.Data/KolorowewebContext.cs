using KoloroweWeb.Data.Entities;
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

    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Offer> Offers { get; set; }
    public virtual DbSet<Image> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;database=koloroweweb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("posts");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.Title).HasColumnType("text");
            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasMany(e => e.Images) 
                .WithOne(i => i.Post)    
                .HasForeignKey(i => i.PostId) 
                .HasConstraintName("ImagesPostsFK") 
                .OnDelete(DeleteBehavior.Cascade); 
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("offers");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Title).HasColumnType("text");
            entity.Property(e => e.Content).HasColumnType("text");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Principals).HasColumnType("text");
            entity.Property(e => e.GroupRed).HasColumnType("text");
            entity.Property(e => e.GroupYellow).HasColumnType("text");
            entity.Property(e => e.GroupBlue).HasColumnType("text");
            entity.Property(e => e.GroupGreen).HasColumnType("text");
            entity.Property(e => e.Specialists).HasColumnType("text");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("images");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.PostId).HasColumnType("int");
            entity.Property(e => e.FileName).HasColumnType("text");

            entity.HasOne(e => e.Post)
                .WithMany(p => p.Images)
                .HasForeignKey(e => e.PostId)
                .HasConstraintName("ImagesPostsFK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
