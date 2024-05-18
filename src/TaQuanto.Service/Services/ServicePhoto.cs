using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.PixelFormats;
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
                    var extencionImage = Path.GetExtension(img.FileName).ToLowerInvariant();
                    if (extencionImage == ".png")
                    {
                        var outputImage = new Image<Rgba32>(image.Width, image.Height);
                        outputImage.Mutate(ctx => ctx.BackgroundColor(Color.White));
                        outputImage.Mutate(ctx => ctx.DrawImage(image, new SixLabors.ImageSharp.Point(0, 0), 1));

                        var encoder = new WebpEncoder { Quality = 50 };
                        using (var outputStream = new MemoryStream())
                        {
                            outputImage.Save(outputStream, encoder);
                            return outputStream.ToArray();
                        }
                    }

                    var enc = new WebpEncoder { Quality = 50 };
                    using (var outputStream = new MemoryStream())
                    {
                        image.Save(outputStream, enc);
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
