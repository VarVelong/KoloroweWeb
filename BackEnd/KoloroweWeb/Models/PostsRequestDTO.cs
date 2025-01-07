namespace KoloroweWeb.Models
{
    public class PostsRequestDTO
    {
        public int? Id { get; set; }

        public DateTime? Date { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public IFormFile? Image { get; set; }
    }
}
