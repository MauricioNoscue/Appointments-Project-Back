using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.Menu
{
    public sealed class FormVisibleDto
    {
        public int FormId { get; set; }
        public string FormName { get; set; } = default!;
        public string Url { get; set; } = default!;
        public string? FormIcon { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; } = default!;
        public string? ModuleIcon { get; set; }
    }
}
