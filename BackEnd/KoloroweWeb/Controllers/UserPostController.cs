using KoloroweWeb.Data;
using KoloroweWeb.Data.Entities;
using KoloroweWeb.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

            var totalCount = await kolorowewebContext.Posts.CountAsync();

            var posts = await kolorowewebContext.Posts
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
        public async Task<ActionResult<PostsResponseDTO>> GetPostByDate(int Id)
        {
            var post = await kolorowewebContext.Posts.Select(
                    s => new PostsResponseDTO
                    {
                        Id = s.Id,
                        Date = s.Date,
                        Content = s.Content,
                        Image = !string.IsNullOrEmpty(s.Image)
                ? $"{Request.Scheme}://{Request.Host}/{s.Image}"
                : null,
                    }).FirstOrDefaultAsync(s => s.Id == Id);

            return post is null ? NotFound() : post;
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

            var entity = new Posts()
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
            var entity = new Posts()
            {
                Id = Id
            };

            kolorowewebContext.Posts.Attach(entity);
            kolorowewebContext.Posts.Remove(entity);
            await kolorowewebContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpPut("{Id}")]
        public async Task<HttpStatusCode> UpdatePostContent([FromRoute] int id,[FromBody] string content)
        {
            var existingPost = await kolorowewebContext.Posts.FindAsync(id);
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
        //    var existingPost = await kolorowewebContext.Posts.FindAsync(id);

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
