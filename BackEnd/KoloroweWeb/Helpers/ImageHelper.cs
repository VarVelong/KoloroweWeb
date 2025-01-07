using KoloroweWeb.Data.Entities;

namespace KoloroweWeb.Helpers
{
    public static class ImageHelper
    {
        public static string GetFullPath(HttpRequest request, Image image)
        {
            return $"{request.Scheme}://{request.Host}/{image.FileName}";
        }

        public static async Task StoreImageFile(string ImageDirectory, IFormFile image)
        {
            string ImagePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ImageDirectory);
            string filePath = Path.Combine(ImagePathDirectory, image.FileName);

            if (!string.IsNullOrEmpty(ImagePathDirectory) && !Directory.Exists(ImagePathDirectory))
            {
                Directory.CreateDirectory(ImagePathDirectory);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
        }
    }
}
