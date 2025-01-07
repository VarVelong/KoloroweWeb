namespace KoloroweWeb.Models
{
    public class ImagesRequestDTO
    {
        public int? Id { get; set; }

        public int? PostId { get; set; }

        public IFormFile Image { get; set; }
    }
}
