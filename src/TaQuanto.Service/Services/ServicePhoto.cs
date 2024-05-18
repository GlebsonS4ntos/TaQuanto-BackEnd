using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
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
            var webpBytes = ConvertToWebP(img);

            using (var stream = new MemoryStream(webpBytes))
            {
                var uploadOpt = new ImageUploadParams()
                {
                    File = new FileDescription(new Guid().ToString(), stream)
                };
                return await _cloudinary.UploadAsync(uploadOpt);
            }
        }

        private byte[] ConvertToWebP(IFormFile img)
        {
            using (var inputStream = img.OpenReadStream())
            {
                using (var image = Image.Load(inputStream))
                {
                    var encoder = new SixLabors.ImageSharp.Formats.Webp.WebpEncoder { Quality = 75 }; // Ajuste a qualidade conforme necessário
                    using (var outputStream = new MemoryStream())
                    {
                        image.Save(outputStream, encoder);
                        return outputStream.ToArray();
                    }
                }
            }
        }

        public async Task<DeletionResult> DeletePhoto(string imgUrl)
        {
            var deleteParameters = new DeletionParams(imgUrl);
            var result = await _cloudinary.DestroyAsync(deleteParameters);
            return result;
        }
    }
}
