using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoloroweWeb.Entities;

public partial class Userpost : DbContext
{
    public int? Id { get; set; }

    public DateTime? Date { get; set; }

    public string Content { get; set; } = null!;

    public string? Image { get; set; }
}
