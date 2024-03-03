using MarketShuffleModels;
using Microsoft.EntityFrameworkCore;

namespace MarketShuffleService.Data_Access;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Item> Items { get; set; }
    public DbSet<ItemPosition> ItemPositions { get; set; }
    public DbSet<RecipeItem> RecipeItems { get; set; }
    public DbSet<Guild> Guilds { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.IsFavorite).IsRequired();
            entity.Property(e => e.Category).IsRequired();
        });

        modelBuilder.Entity<RecipeItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Quantity).IsRequired();
            entity.Property(e => e.ParentItemId).IsRequired();

            entity.HasOne(e => e.ParentItem)
            .WithMany(e => e.Recipe)
            .HasForeignKey(e => e.ParentItemId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ItemPosition>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Details).IsRequired();
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.ParentItemId).IsRequired();

            entity.HasOne(e => e.ParentItem)
            .WithMany(e => e.Positions)
            .HasForeignKey(e => e.ParentItemId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Guild>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Level).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Difficult).IsRequired();
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Class).IsRequired();
            entity.Property(e => e.Level).IsRequired();
            entity.Property(e => e.Exoed).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.SeenOnline).IsRequired();
            entity.Property(e => e.Ap).IsRequired();
            entity.Property(e => e.Mp).IsRequired();

            entity.HasOne(e => e.Guild)
            .WithMany(e => e.Players)
            .HasForeignKey(e => e.GuildId)
            .OnDelete(DeleteBehavior.Cascade);
        });
    }
}