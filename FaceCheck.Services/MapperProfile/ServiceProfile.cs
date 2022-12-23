using AutoMapper;
using FaceCheck.Entity.Models;
using FaceCheck.Services.Models;

namespace FaceCheck.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {

        #region Admin

        
        CreateMap<Admin, AdminModel>().ReverseMap();
        CreateMap<Admin, AdminPreviewModel>()
            .ForMember(x => x.Login, y => y.MapFrom(u => u.Login));

        #endregion
        #region Users

        
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name))
            .ForMember(x => x.Email, y => y.MapFrom(u => u.Email));

        #endregion

        #region Chat

        CreateMap<Chat, ChatModel>().ReverseMap();
        CreateMap<Chat, ChatPreviewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(u => u.Name));

        #endregion
        #region Photo

        CreateMap<Photo, PhotoModel>().ReverseMap();
        CreateMap<Photo, PhotoPreviewModel>()
            .ForMember(x => x.Photo, y => y.MapFrom(u => u.Photo));

        #endregion

        
    }
}