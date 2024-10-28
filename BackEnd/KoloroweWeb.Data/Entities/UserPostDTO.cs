using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoloroweWeb.Data.Entities
{
    internal class UserPostDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; } = null!;

        public string? Image { get; set; }
    }
}
