namespace KoloroweWeb.Data.Entities;

public class Image
{
    public int? Id { get; set; }

    public int? PostId { get; set; }

    public string FileName { get; set; }

    public Post? Post { get; set; } // Navigation property
}
