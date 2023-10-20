using Share.DataAccess.Contexts;
using Share.DataAccess.Contracts;
using Share.Domain.Entities.Attachments;
using Share.Domain.Entities.Comments;
using Share.Domain.Entities.Follows;
using Share.Domain.Entities.LikedStories;
using Share.Domain.Entities.SavedStories;
using Share.Domain.Entities.Stories;
using Share.Domain.Entities.StoryImages;
using Share.Domain.Entities.UserProfileImages;
using Share.Domain.Entities.Users;

namespace Share.DataAccess.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext, 
                        IRepository<Attachment> attachmentRepositroy, 
                        IRepository<Comment> commentRepository, 
                        IRepository<Follow> followRepository, 
                        IRepository<LikedStory> likedStoryRepository, 
                        IRepository<SavedStory> savedStoryRepository,
                        IRepository<Story> storyRepository,
                        IRepository<StoryImage> storyImageRepository, 
                        IRepository<User> userRepository,
                        IRepository<UserProfileImage> userProfileImageRepository)
    {
        _dbContext = dbContext;
        AttachmentRepositroy = attachmentRepositroy;
        CommentRepository = commentRepository;
        FollowRepository = followRepository;
        LikedStoryRepository = likedStoryRepository;
        SavedStoryRepository = savedStoryRepository;
        StoryRepository = storyRepository;
        StoryImageRepository = storyImageRepository;
        UserRepository = userRepository;
        UserProfileImageRepository = userProfileImageRepository;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public IRepository<Attachment> AttachmentRepositroy { get; }
    public IRepository<Comment> CommentRepository { get; }
    public IRepository<Follow> FollowRepository { get; }
    public IRepository<LikedStory> LikedStoryRepository { get; }
    public IRepository<SavedStory> SavedStoryRepository { get; }
    public IRepository<Story> StoryRepository { get; }
    public IRepository<StoryImage> StoryImageRepository { get; }
    public IRepository<User> UserRepository { get; }
    public IRepository<UserProfileImage> UserProfileImageRepository { get; }
    
    public async ValueTask SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}