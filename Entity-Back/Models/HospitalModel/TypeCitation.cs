using Entity_Back.Models;

namespace Entity_Back
{
    public class TypeCitation : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public List<Shedule> Shedules { get; set; }
    }

}