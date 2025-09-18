using Entity_Back.Models;
using Entity_Back.Models.SecurityModels;
using Entity_Back.Models.HospitalModel;

namespace Entity_Back
{
    public class Doctor : BaseModel
    {
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
        public bool Active { get; set; }
        public  string? EmailDoctor { get; set; }
        public string Image { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public  List<Shedule> Shedules { get; set; }
    }
}


