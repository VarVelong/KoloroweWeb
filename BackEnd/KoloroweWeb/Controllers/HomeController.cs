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
        private readonly DbContext DBContext;

        public UserPostController(DbContext DBContext)
        {
            this.DBContext = DBContext;
        }

    }

    [HttpGet("GetPost")]
    public async Task<ActionResult<List<UserPostDTO>>> Get()
    {
        var Post = await DbContext.Userpost.Select(
            s => new UserPostDTO
            {
                Id = s.Id,
                Date = s.Date,
                Content = s.Content,
                Image = s.Image,
            }
        ).ToListAsync();

    //    if (Post.Count < 0)
    //    {
    //        return "NotFound"();
    //    }
    //    else
    //    {
    //        return Post;
    //    }
    }

    [HttpGet("GetPostByDate")]
    public async Task<ActionResult<UserPostDTO>> GetUserByDate(int Id)
    {
        Userpost Post = await DbContext.Userpost.Select(
                s => new UserPostDTO
                {
                    Id = s.Id,
                    Date = s.Date,
                    Content = s.Content,
                    Image = s.Image,
                })
            .FirstOrDefaultAsync(s => s.Id == Id);

        //if (Post == null)
        //{
        //    return "NotFound"();
        //}
        //else
        //{
        //    return Post;
        //}


        [HttpPut("UpdatePost")]
        async Task<HttpStatusCode> UpdatePost(UserPostDTO User)
        {
            var entity = await DbContext.User.FirstOrDefaultAsync(s => s.Id == User.Id);

            entity.Id = User.Id;
            entity.Date = User.Date;
            entity.Content = User.Content;
            entity.Image = User.Image;

            await DbContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }

    [HttpDelete("DeletePost/{Id}")]
    public async Task<HttpStatusCode> DeletePost(int Id)
    {
        var entity = new Post()
        {
            Id = Id
        };
        DbContext.User.Attach(entity);
        DbContext.User.Remove(entity);
        await DbContext.SaveChangesAsync();
        return HttpStatusCode.OK;
    }

}
