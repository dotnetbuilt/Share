using Microsoft.EntityFrameworkCore;
using Share.Domain.Entities.Attachments;
using Share.Domain.Entities.Comments;
using Share.Domain.Entities.Follows;
using Share.Domain.Entities.LikedStories;
using Share.Domain.Entities.SavedStories;
using Share.Domain.Entities.Stories;
using Share.Domain.Entities.StoryImages;
using Share.Domain.Entities.UserProfileImages;
using Share.Domain.Entities.Users;

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
    public DbSet<SavedStory> SavedStories { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<StoryImage> StoryImages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfileImage> UserProfileImages { get; set; }
}