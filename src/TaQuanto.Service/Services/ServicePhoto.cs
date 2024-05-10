using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TaQuanto.Service.Helpers;
using TaQuanto.Service.Interfaces;

namespace TaQuanto.Service.Services
{
    public class ServicePhoto : IServicePhoto
    {
        private readonly Cloudinary _cloudinary;

        public ServicePhoto(IOptions<CloudinaryConfig> cloudinaryConfig)
        {
            var acc = new Account
            (
                cloudinaryConfig.Value.CloudName,
                cloudinaryConfig.Value.ApiKey,
                cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> AddPhoto(IFormFile img)
        {
            var stream = img.OpenReadStream();
            var uploadOpt = new ImageUploadParams()
            {
                File = new FileDescription(new Guid().ToString(), stream)
            };
            return await _cloudinary.UploadAsync(uploadOpt);
        }

        public async Task<DeletionResult> DeletePhoto(string imgUrl)
        {
            var deleteParameters = new DeletionParams(imgUrl);
            var result = await _cloudinary.DestroyAsync(deleteParameters);
            return result;
        }
    }
}
