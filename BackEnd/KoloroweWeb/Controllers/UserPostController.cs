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
        public async Task<ActionResult<PaginatedResponse<PostsResponseDTO>>> Get(int page = 1, int pageSize = 5)
        {
            if (page < 1 || pageSize < 1)
            {
                return BadRequest("Page and pageSize must be greater than zero.");
            }

            var totalCount = await kolorowewebContext.Userposts.CountAsync();

            var posts = await kolorowewebContext.Userposts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new PostsResponseDTO
                {
                    Id = s.Id,
                    Date = s.Date,
                    Content = s.Content,
                    Image = !string.IsNullOrEmpty(s.Image)
                        ? $"{Request.Scheme}://{Request.Host}/{s.Image}"
                        : null,
                })
                .ToListAsync();

            var paginatedResponse = new PaginatedResponse<PostsResponseDTO>
            {
                Data = posts,
                TotalCount = totalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return paginatedResponse;
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
                        Image = !string.IsNullOrEmpty(s.Image)
                ? $"{Request.Scheme}://{Request.Host}/{s.Image}"
                : null,
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
            

            if (post.Image != null)
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
            }

            var entity = new Userpost()
            {
                Id = post.Id,
                Date = post.Date,
                Content = post.Content,
                Image = post.Image != null ? $"/{ImageDirectory}/{post.Image.FileName}" : null,
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

        [HttpPut("{Id}")]
        public async Task<HttpStatusCode> UpdatePostContent([FromRoute] int id,[FromBody] string content)
        {
            var existingPost = await kolorowewebContext.Userposts.FindAsync(id);

            if (existingPost == null)
            {
                return HttpStatusCode.NotFound;
            }

            existingPost.Content = content;

            await kolorowewebContext.SaveChangesAsync();

            return HttpStatusCode.OK;
        }   

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdatePostContent(int id, [FromBody] UpdatePostDto updatePostDto)
        //{
        //    var existingPost = await kolorowewebContext.Userposts.FindAsync(id);

        //    if (existingPost == null)
        //    {
        //        return NotFound(new { Message = "Post not found" });
        //    }

        //    existingPost.Content = updatePostDto.NewContent;

        //    await kolorowewebContext.SaveChangesAsync();

        //    return Ok(new { Message = "Post updated successfully" });
        //}
    }
}


