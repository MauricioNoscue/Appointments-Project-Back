using Entity_Back.Models;

namespace Entity_Back
{
    public class CitationListDto : BaseModel
    {
        public string State { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}