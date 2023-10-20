using AutoMapper;
using Share.Domain.Entities;
using Share.Service.DTOs.Attachments;
using Share.Service.DTOs.Comments;
using Share.Service.DTOs.Follows;
using Share.Service.DTOs.LikedStories;
using Share.Service.DTOs.Replies;
using Share.Service.DTOs.SavedStories;
using Share.Service.DTOs.Stories;
using Share.Service.DTOs.StoryImages;
using Share.Service.DTOs.UserProfileImages;
using Share.Service.DTOs.Users;

namespace Share.Service.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        //Comment
        CreateMap<Comment, CommentCreationDto>().ReverseMap();
        CreateMap<Comment, CommentUpdateDto>().ReverseMap();
        CreateMap<Comment, CommentResultDto>().ReverseMap();
        
        //Follow
        CreateMap<Follow, FollowCreationDto>().ReverseMap();
        
        //LikedStory
        CreateMap<LikedStory, LikedStoryCreationDto>().ReverseMap();
        
        //Reply
        CreateMap<Reply, ReplyCreationDto>().ReverseMap();
        CreateMap<Reply, ReplyUpdateDto>().ReverseMap();
        CreateMap<Reply, ReplyResultDto>().ReverseMap();
        
        //SavedStory
        CreateMap<SavedStory, SavedStoryCreationDto>().ReverseMap();
        
        //Story
        CreateMap<Story, StoryCreationDto>().ReverseMap();
        CreateMap<Story, StoryUpdateDto>().ReverseMap();
        CreateMap<Story, StoryResultDto>().ReverseMap();
        
        //StoryImage
        CreateMap<StoryImage, StoryImageResultDto>().ReverseMap();
        
        //User
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<UserResultDto, User>().ReverseMap();
        
        //UserProfileImage
        CreateMap<UserProfileImage, UserProfileImageResultDto>().ReverseMap();
        
        //Attachment
        CreateMap<Attachment, AttachmentResultDto>().ReverseMap();
    }
}