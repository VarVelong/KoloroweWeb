using Microsoft.AspNetCore.Http;

namespace KoloroweWeb.Data.Entities
{
    public class ImagesRequestDTO
    {
        public int? Id { get; set; }

        public int? PostId { get; set; }

        public IFormFile Image { get; set; }
    }
}
