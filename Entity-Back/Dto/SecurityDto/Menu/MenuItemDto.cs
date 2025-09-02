using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.Menu
{
    public  class MenuItemDto
    {
        public string Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Type { get; set; } = default!; // "group" | "collapse" | "item"
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public List<MenuItemDto> Children { get; set; } = new();
    }
}
