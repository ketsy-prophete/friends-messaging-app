using myApi.Models;
using Microsoft.EntityFrameworkCore;

namespace myApi.Migrations;

public class TweetDbContext : DbContext
{
    public DbSet<Tweet> Tweet { get; set; }
    public DbSet<User> Users { get; set; }

    public TweetDbContext(DbContextOptions<TweetDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tweet>(entity =>
        {
            entity.HasKey(e => e.TweetId);
            entity.Property(e => e.TweetMessage).IsRequired();
            entity.Property(e => e.UserName).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        modelBuilder.Entity<Tweet>().HasData(
            new Tweet
            {
                TweetId = 1,
                TweetMessage = "Hello there! This is my first tweet!👋",
                UserName = "TestUser1",
                CreatedAt = DateTime.Now
            },
            new Tweet
            {
                TweetId = 2,
                TweetMessage = "Ahh! I love this app, so cool!👏",
                UserName = "TestUser2",
                CreatedAt = DateTime.Now
            }
        );

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserName).IsRequired();
            entity.HasIndex(x => x.UserName).IsUnique();
            entity.Property(e => e.Password).IsRequired();
        });
    }
}