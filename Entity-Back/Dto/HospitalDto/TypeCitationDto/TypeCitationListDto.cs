using Entity_Back.Models;

namespace Entity_Back
{
    public class TypeCitationListDto : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public bool HasShedule { get; set; }
    }
}