using Share.DataAccess.Contexts;
using Share.DataAccess.Contracts;
using Share.Domain.Entities;

namespace Share.DataAccess.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext, IRepository<Attachment> attachmentRepositroy, IRepository<Comment> commentRepository, IRepository<Follow> followRepository, IRepository<LikedStory> likedStoryRepository, IRepository<Reply> replyRepository, IRepository<SavedStory> savedStoryRepository, IRepository<Story> storyRepository, IRepository<StoryImage> storyImageRepository, IRepository<User> userRepository, IRepository<UserProfileImage> userProfileImageRepository)
    {
        _dbContext = dbContext;
        AttachmentRepositroy = attachmentRepositroy;
        CommentRepository = commentRepository;
        FollowRepository = followRepository;
        LikedStoryRepository = likedStoryRepository;
        ReplyRepository = replyRepository;
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
    public IRepository<Reply> ReplyRepository { get; }
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