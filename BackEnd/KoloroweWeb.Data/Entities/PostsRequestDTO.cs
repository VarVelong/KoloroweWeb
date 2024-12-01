using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoloroweWeb.Data.Entities
{
    public class PostsRequestDTO
    {
        public int? Id { get; set; }

        public DateTime? Date { get; set; }

        public string Content { get; set; }

        public IFormFile? Image { get; set; }
    }
}
