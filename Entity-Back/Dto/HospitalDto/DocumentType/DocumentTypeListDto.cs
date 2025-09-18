using Entity_Back.Models;

namespace Entity_Back
{
    public class DocumentTypeListDto : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;
    }
}