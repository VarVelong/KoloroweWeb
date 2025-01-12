using KoloroweWeb.Data.Entities;
using KoloroweWeb.Data.Repositories;
using KoloroweWeb.Helpers;
using KoloroweWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KoloroweWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalleryController : Controller
    {
        private readonly IRepository<Image> imageRepository;
        private const string ImageDirectory = "ImageGallery";

        public GalleryController(IRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<ImagesResponseDTO>>> Get(int page = 1, int pageSize = 15)
        {
            if (page < 1 || pageSize < 1)
            {
                return BadRequest("Page and pageSize must be greater than zero.");
            }

            var paginatedImages = await imageRepository.GetPaginatedAsync(page, pageSize, i => i.PostId == null);

            var paginatedImagesList = new PaginatedResponse<ImagesResponseDTO>
            {
                Data = paginatedImages.Data.Select(s => new ImagesResponseDTO
                {
                    Id = s.Id,
                    PostId = s.PostId,
                    FileName = ImageHelper.GetFullPath(Request, s)
                }).ToList(),
                TotalCount = paginatedImages.TotalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(paginatedImages.TotalCount / (double)pageSize)
            };

            return paginatedImagesList;
        }

        [HttpPost]
        [Authorize]
        public async Task<HttpStatusCode> InsertImage(IFormFile image)
        {
            if (image == null)
            {
                return HttpStatusCode.NoContent;
            }

            await ImageHelper.StoreImageFile(ImageDirectory, image);

            var entity = new Image()
            {
                FileName = $"/{ImageDirectory}/{image.FileName}"
            };

            await imageRepository.AddAsync(entity);
            return HttpStatusCode.Created;
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<HttpStatusCode> DeleteImage(int Id)
        {
            Image entity = new Image()
            {
                Id = Id
            };

            await imageRepository.RemoveAsync(entity);
            return HttpStatusCode.OK;
        }
    }
}
