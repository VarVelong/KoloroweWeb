namespace KoloroweWeb.Data.Entities;

public class Post
{
    public int? Id { get; set; }

    public DateTime? Date { get; set; }

    public string Title { get; set; }

    public string Content { get; set; } = null!;

    public ICollection<Image>? Images { get; set; }
}
