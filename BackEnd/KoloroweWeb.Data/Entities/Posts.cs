using static System.Net.Mime.MediaTypeNames;

namespace KoloroweWeb.Entities;

public class Posts
{
    public int? Id { get; set; }

    public DateTime? Date { get; set; }
    public string Title { get; set; }

    public string Content { get; set; } = null!;

    public ICollection<Images>? Images { get; set; }
}
