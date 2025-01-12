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
    public class PostController : ControllerBase
    {
        private readonly IRepository<Post> postRepository;
        private readonly IRepository<Image> imageRepository;
        private const string ImageDirectory = "PostImages";

        public PostController(IRepository<Post> postRepository, IRepository<Image> imageRepository)
        {
            this.postRepository = postRepository;
            this.imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<PostsResponseDTO>>> Get(int page = 1, int pageSize = 5)
        {
            if (page < 1 || pageSize < 1)
            {
                return BadRequest("Page and pageSize must be greater than zero.");
            }

            var paginatedPosts = await postRepository.GetPaginatedAsync(page, pageSize);

            var paginatedResponse = new PaginatedResponse<PostsResponseDTO>
            {
                Data = paginatedPosts.Data.Select(s => new PostsResponseDTO
                {
                    Id = s.Id,
                    Date = s.Date,
                    Title = s.Title,
                    Content = s.Content,
                    Image = s.Images != null && s.Images.Any()
                            ? s.Images
                                .Where(img => img.PostId == s.Id)
                                .Select(img => ImageHelper.GetFullPath(Request, img))
                                .FirstOrDefault()
                            : null
                }).ToList(),
                TotalCount = paginatedPosts.TotalCount,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(paginatedPosts.TotalCount / (double)pageSize)
            };

            return paginatedResponse;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostsResponseDTO>> Get(int id)
        {
            var post = await postRepository.GetByIdAsync(id, p => p.Images);
            if (post is null)
            {
                return NotFound();
            }

            var postResponse = new PostsResponseDTO
            {
                Id = post.Id,
                Date = post.Date,
                Content = post.Content,
                Title = post.Title,
                Image = post.Images != null && post.Images.Any()
                            ? post.Images
                                .Where(img => img.PostId == post.Id)
                                .Select(img => ImageHelper.GetFullPath(Request, img))
                                .FirstOrDefault()
                            : null
            };

            return postResponse;
        }

        [HttpPost]
        [Authorize]
        public async Task<HttpStatusCode> InsertPost(PostsRequestDTO post)
        {
            Post postEntity = new Post()
            {
                Id = post.Id,
                Date = post.Date,
                Content = post.Content,
                Title = post.Title
            };

            await postRepository.AddAsync(postEntity);
            if (post.Image != null)
            {
                await ImageHelper.StoreImageFile(ImageDirectory, post.Image);

                var imageEntity = new Image
                {
                    PostId = postEntity.Id, 
                    FileName = $"/{ImageDirectory}/{post.Image.FileName}"
                };

                await imageRepository.AddAsync(imageEntity);
            }

            return HttpStatusCode.Created;
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<HttpStatusCode> DeletePost(int Id)
        {
            Post entity = new Post()
            {
                Id = Id
            };

            await postRepository.RemoveAsync(entity);
            return HttpStatusCode.OK;
        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<HttpStatusCode> UpdatePostContent([FromRoute] int id, [FromBody] string content)
        {
            var existingPost = await postRepository.GetByIdAsync(id);
            if (existingPost == null)
            {
                return HttpStatusCode.NotFound;
            }

            existingPost.Content = content;
            await postRepository.UpdateAsync(existingPost);

            return HttpStatusCode.OK;
        }
    }
}
