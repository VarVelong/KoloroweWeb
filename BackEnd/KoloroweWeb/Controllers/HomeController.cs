using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoloroweWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPostController : ControllerBase
    {
        private readonly DBContext DBContext;

        public UserPostController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }
  
     }
}
