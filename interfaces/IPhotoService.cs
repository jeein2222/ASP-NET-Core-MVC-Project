using CloudinaryDotNet.Actions;

namespace NETCoreMVCProject.interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);  
    }
}
