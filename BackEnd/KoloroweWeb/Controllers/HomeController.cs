using KoloroweWeb.Data.Entities;
using KoloroweWeb.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace KoloroweWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPostController : ControllerBase
    {
        private readonly KolorowewebContext kolorowewebContext;

        public UserPostController(KolorowewebContext kolorowewebContext)
        {
            this.kolorowewebContext = kolorowewebContext;
        }



        [HttpGet("GetPost")]
        public async Task<ActionResult<List<UserPostDTO>>> Get()
        {
            var post = await kolorowewebContext.Userposts.Select(
                s => new UserPostDTO
                {
                    Id = s.Id,
                    Date = s.Date,
                    Content = s.Content,
                    Image = s.Image,
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

        [HttpGet("GetPostByDate")]
        public async Task<ActionResult<UserPostDTO>> GetUserByDate(int Id)
        {
            var post = await kolorowewebContext.Userposts.Select(
                    s => new UserPostDTO
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


            [HttpPut("UpdatePost")]
            async Task<HttpStatusCode> UpdatePost(UserPostDTO User)
            {
                var entity = await kolorowewebContext.Userposts.FirstOrDefaultAsync(s => s.Id == User.Id);

                entity.Id = User.Id;
                entity.Date = User.Date;
                entity.Content = User.Content;
                entity.Image = User.Image;

                await kolorowewebContext.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
        }

        [HttpDelete("DeletePost/{Id}")]
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
