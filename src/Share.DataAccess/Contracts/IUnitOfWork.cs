using Share.Domain.Entities.Attachments;
using Share.Domain.Entities.Comments;
using Share.Domain.Entities.Follows;
using Share.Domain.Entities.LikedStories;
using Share.Domain.Entities.Replies;
using Share.Domain.Entities.SavedStories;
using Share.Domain.Entities.Stories;
using Share.Domain.Entities.StoryImages;
using Share.Domain.Entities.UserProfileImages;
using Share.Domain.Entities.Users;

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