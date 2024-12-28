using KoloroweWeb.Data.Entities;
using KoloroweWeb.Data;
using KoloroweWeb.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace KoloroweWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GalleryController : Controller
    {
        private readonly KolorowewebContext kolorowewebContext;
        private const string ImageDirectory = "ImageGallery";
        private readonly string ImagePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ImageDirectory);

        public GalleryController(KolorowewebContext kolorowewebContext)
        {
            this.kolorowewebContext = kolorowewebContext;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<ImagesResponseDTO>>> Get(int page = 1, int pageSize = 3)
        {
            if (page < 1 || pageSize < 1)
            {
                return BadRequest("Page and pageSize must be greater than zero.");
            }

            var totalCount = await kolorowewebContext.Images
                .Where(i => i.PostId == null)
                .CountAsync();

            var images = await kolorowewebContext.Images
                .Where(i => i.PostId == null)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new ImagesResponseDTO
                {
                    Id = s.Id,
                    PostId = s.PostId,
                    FileName = $"{Request.Scheme}://{Request.Host}/{s.FileName}"
                })
                .ToListAsync();

            var paginatedResponse = new PaginatedResponse<ImagesResponseDTO>
            {
                Data = images,
                TotalCount = totalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return paginatedResponse;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImagesResponseDTO>> GetImageByDate(int Id)
        {
            var image = await kolorowewebContext.Images.Select(
                    s => new ImagesResponseDTO
                    {
                        Id = s.Id,
                        PostId = s.PostId,
                        FileName = $"{Request.Scheme}://{Request.Host}/{s.FileName}"
                    }).FirstOrDefaultAsync(s => s.Id == Id);

            return image is null ? NotFound() : image;
        }

        [HttpPost]
        [Authorize]
        public async Task<HttpStatusCode> InsertImage(IFormFile image)
        {
            if (image == null)
            {
                return HttpStatusCode.NoContent;
            }

            var filePath = Path.Combine(ImagePathDirectory, image.FileName);

            if (!string.IsNullOrEmpty(ImagePathDirectory) && !Directory.Exists(ImagePathDirectory))
            {
                Directory.CreateDirectory(ImagePathDirectory);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var entity = new Images()
            {
                FileName = $"/{ImageDirectory}/{image.FileName}"
            };

            kolorowewebContext.Add(entity);
            await kolorowewebContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<HttpStatusCode> DeleteImage(int Id)
        {
            var entity = new Images()
            {
                Id = Id
            };

            kolorowewebContext.Images.Attach(entity);
            kolorowewebContext.Images.Remove(entity);
            await kolorowewebContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
