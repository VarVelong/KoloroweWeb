using KoloroweWeb.Data.Entities;
using KoloroweWeb.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace KoloroweWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserPostController : ControllerBase
    {
        private readonly KolorowewebContext kolorowewebContext;
        private const string ImageDirectory = "PostImages";
        private readonly string ImagePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ImageDirectory);


        public UserPostController(KolorowewebContext kolorowewebContext)
        {
            this.kolorowewebContext = kolorowewebContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostsResponseDTO>>> Get()
        {
            var post = await kolorowewebContext.Userposts.Select(
                s => new PostsResponseDTO
                {
                    Id = s.Id,
                    Date = s.Date,
                    Content = s.Content,
                    Image = !string.IsNullOrEmpty(s.Image)
                ? $"{Request.Scheme}://{Request.Host}/{ImageDirectory}/{s.Image}"
                : null,
                }
            ).ToListAsync();

            if (post.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return post;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostsResponseDTO>> GetUserByDate(int Id)
        {
            var post = await kolorowewebContext.Userposts.Select(
                    s => new PostsResponseDTO
                    {
                        Id = s.Id,
                        Date = s.Date,
                        Content = s.Content,
                        Image = s.Image,
                    }).FirstOrDefaultAsync(s => s.Id == Id);

            if (post == null)
            {
                return NotFound();
            }
            else
            {
                return post;
            }
        }

        
        [HttpPost("post")]
        [Authorize]
        public async Task<HttpStatusCode> InsertPost(PostsRequestDTO post)
        {
            var filePath = Path.Combine(ImagePathDirectory, post.Image.FileName);

            if (!string.IsNullOrEmpty(ImagePathDirectory) && !Directory.Exists(ImagePathDirectory))
            {
                Directory.CreateDirectory(ImagePathDirectory);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await post.Image.CopyToAsync(stream);
            }

            var entity = new Userpost()
            {
                Id = post.Id,
                Date = post.Date,
                Content = post.Content,
                Image = $"/{ImageDirectory}/{post.Image.FileName}",
            };

            kolorowewebContext.Add(entity);
            await kolorowewebContext.SaveChangesAsync();

            return HttpStatusCode.Created;
        }

        [HttpDelete("{Id}")]
        public async Task<HttpStatusCode> DeletePost(int Id)
        {
            var entity = new Userpost()
            {
                Id = Id
            };
            kolorowewebContext.Userposts.Attach(entity);
            kolorowewebContext.Userposts.Remove(entity);
            await kolorowewebContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


    }
}
