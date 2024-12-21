namespace KoloroweWeb.Entities;

public partial class Images
{
    public int? Id { get; set; }

    public int? PostId { get; set; }

    public string FileName { get; set; }

    public Posts? Post { get; set; } // Navigation property
}
