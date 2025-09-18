using Entity_Back.Models;

namespace Entity_Back
{
    public class SpecialtyListDto : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}