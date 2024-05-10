using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace TaQuanto.Service.Interfaces
{
    public interface IServicePhoto
    {
        Task<ImageUploadResult> AddPhoto(IFormFile img);
        Task<DeletionResult> DeletePhoto(string imgPublicId);
    }
}
