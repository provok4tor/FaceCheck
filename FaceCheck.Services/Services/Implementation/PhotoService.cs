using AutoMapper;
using FaceCheck.Entity.Models;
using FaceCheck.Repository;
using FaceCheck.Services.Abstract;
using FaceCheck.Services.Models;

namespace FaceCheck.Services.Implementation;

public class PhotoService :IPhotoService
{
    private readonly IRepository<Photo> photoRepository;
    private readonly IMapper mapper;
    public PhotoService(IRepository<Photo> photoRepository, IMapper mapper)
    {
        this.photoRepository = photoRepository;
        this.mapper = mapper;
    }

    public void DeletePhoto(Guid id)
    {
        var photoToDelete =photoRepository.GetById(id);
        if (photoToDelete == null)
        {
            throw new Exception("Photo not found");
        }
        photoRepository.Delete(photoToDelete);
    }

    public PhotoModel GetPhoto(Guid id)
    {
        var photo =photoRepository.GetById(id);
        return mapper.Map<PhotoModel>(photo);
    }

    public PageModel<PhotoPreviewModel> GetPhotos(int limit = 20, int offset = 0)
    {
        var photo =photoRepository.GetAll();
        int totalCount =photo.Count();
        var chunk=photo.OrderBy(x=>x.Name).Skip(offset).Take(limit);

        return new PageModel<PhotoPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<PhotoPreviewModel>>(photo),
            TotalCount = totalCount
        };
    }

    public PhotoModel UpdatePhoto(Guid id, UpdatePhotoModel photo)
    {
        var existingPhoto = photoRepository.GetById(id);
        if (existingPhoto == null)
        {
            throw new Exception("Photo not found");
        }
        existingPhoto.Name=photo.Name;
        existingPhoto = photoRepository.Save(existingPhoto);
        return mapper.Map<PhotoModel>(existingPhoto);
    }
    public PhotoModel CreatePhoto(PhotoModel photoModel)
    {
        if(photoRepository.GetAll(x=>x.Id==photoModel.Id).FirstOrDefault()!=null)
       {
        throw new Exception ("Attempt to create a non-unique object!");
       }
       PhotoModel create=new PhotoModel();
       create.Name=photoModel.Name;
       photoRepository.Save(mapper.Map<Entity.Models.Photo>(create));
       return create;

    }
}