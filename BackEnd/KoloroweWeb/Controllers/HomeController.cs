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
    [Route("userpost")]
    public class UserPostController : ControllerBase
    {
        private readonly KolorowewebContext kolorowewebContext;

        public UserPostController(KolorowewebContext kolorowewebContext)
        {
            this.kolorowewebContext = kolorowewebContext;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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
        }

        //[HttpPut("{id}")]
        //public async Task<HttpStatusCode> UpdatePost(int id, UserPostDTO post)
        //{
        //    var entity = await kolorowewebContext.Userposts.FirstOrDefaultAsync(s => s.Id == post.Id);

        //    entity.Id = post.Id;
        //    entity.Date = post.Date;
        //    entity.Content = post.Content;
        //    entity.Image = post.Image;

        //    await kolorowewebContext.SaveChangesAsync();

        //    if (id != post.Id)
        //    {
        //        return HttpStatusCode.BadRequest;
        //    }
        //    else 
        //    { 
        //        return HttpStatusCode.OK; 
        //    }
        //}

        [HttpPost("post")]
        public async Task<HttpStatusCode> InsertPost([FromBody]UserPostDTO post)
        {
            //var entity = new Userpost()
            //{
            //    Id = post.Id,
            //    Date = post.Date,
            //    Content = post.Content,
            //    Image = post.Image,
            //};

            //kolorowewebContext.Add(entity);
            //await kolorowewebContext.SaveChangesAsync();

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
