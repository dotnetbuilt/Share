using Share.DataAccess.Contracts;
using Share.DataAccess.Repositories;
using Share.Service.Interfaces;
using Share.Service.Mappers;
using Share.Service.Services;

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

        services.AddAutoMapper(typeof(MappingProfile));
    }
}