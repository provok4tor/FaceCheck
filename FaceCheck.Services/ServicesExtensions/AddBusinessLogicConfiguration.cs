using FaceCheck.Services.Abstract;
using FaceCheck.Services.Implementation;
using FaceCheck.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;
namespace FaceCheck.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));
        //services
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IPhotoService, PhotoService>();
    }
}