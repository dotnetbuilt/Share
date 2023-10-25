using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Share.DataAccess.Contracts;
using Share.DataAccess.Repositories;
using Share.Service.Interfaces.Attachments;
using Share.Service.Interfaces.Comments;
using Share.Service.Interfaces.Follows;
using Share.Service.Interfaces.LikedStories;
using Share.Service.Interfaces.SavedStories;
using Share.Service.Interfaces.Stories;
using Share.Service.Interfaces.StoryImages;
using Share.Service.Interfaces.UserProfileImages;
using Share.Service.Interfaces.Users;
using Share.Service.Mappers;
using Share.Service.Services.Attachments;
using Share.Service.Services.CommentService;
using Share.Service.Services.Follows;
using Share.Service.Services.LikedStories;
using Share.Service.Services.SavedStoryService;
using Share.Service.Services.Stories;
using Share.Service.Services.StoryImages;
using Share.Service.Services.UserProfileImages;
using Share.Service.Services.Users;

namespace Share.Api.Extensions;

public static class ServiceCollection
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IAttachmentService, AttachmentService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserProfileImageService, UserProfileImageService>();
        services.AddScoped<IStoryService, StoryService>();
        services.AddScoped<IStoryImageService, StoryImageService>();
        services.AddScoped<IFollowService, FollowService>();
        services.AddScoped<ISavedStoryService, SavedStoryService>();
        services.AddScoped<ILikedStoryService, LikedStoryService>();
        services.AddScoped<ICommentService, CommentService>();

        services.AddAutoMapper(typeof(MappingProfile));
    }

    public static void AddJwt(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>{
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };
        });
    }
}