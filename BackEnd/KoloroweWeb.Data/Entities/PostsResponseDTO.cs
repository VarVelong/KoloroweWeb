namespace KoloroweWeb.Entities;

public partial class PostsResponseDTO
{
    public int? Id { get; set; }

    public DateTime? Date { get; set; }

    public string Content { get; set; } = null!;

    public string? Image { get; set; }
}
