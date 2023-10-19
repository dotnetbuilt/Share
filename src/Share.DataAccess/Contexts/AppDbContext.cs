using Microsoft.EntityFrameworkCore;
using Share.Domain.Entities;

namespace Share.DataAccess.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }

    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Follow> Follows { get; set; }
    public DbSet<LikedStory> LikedStories { get; set; }
    public DbSet<Reply> Replies { get; set; }
    public DbSet<SavedStory> SavedStories { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<StoryImage> StoryImages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfileImage> UserProfileImages { get; set; }
}