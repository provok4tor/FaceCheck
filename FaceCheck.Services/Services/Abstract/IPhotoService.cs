using FaceCheck.Services.Models;
namespace FaceCheck.Services.Abstract;

public interface IPhotoService
{
   PhotoModel GetPhoto(Guid id);

    PhotoModel UpdatePhoto(Guid id, UpdatePhotoModel photo);

    void DeletePhoto(Guid id);

    PageModel<PhotoPreviewModel> GetPhotos(int limit = 20, int offset = 0);
    PhotoModel CreatePhoto(PhotoModel photoModel);
}