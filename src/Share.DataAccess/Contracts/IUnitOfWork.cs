using Share.Domain.Entities;

namespace Share.DataAccess.Contracts;

public interface IUnitOfWork:IDisposable
{
    IRepository<Attachment> AttachmentRepositroy { get; }
    IRepository<Comment> CommentRepository { get; }
    IRepository<Follow> FollowRepository { get; }
    IRepository<LikedStory> LikedStoryRepository { get; }
    IRepository<Reply> ReplyRepository { get; }
    IRepository<SavedStory> SavedStoryRepository { get; }
    IRepository<Story> StoryRepository { get; }
    IRepository<StoryImage> StoryImageRepository { get; }
    IRepository<User> UserRepository { get; }
    IRepository<UserProfileImage> UserProfileImageRepository { get; }

    ValueTask SaveAsync();
}