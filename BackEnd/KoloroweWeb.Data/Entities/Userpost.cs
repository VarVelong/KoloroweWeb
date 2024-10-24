using System;
using System.Collections.Generic;

namespace KoloroweWeb.Entities;

public partial class Userpost
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Content { get; set; } = null!;

    public string? Image { get; set; }
}
