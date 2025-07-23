using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;
using Entity_Back.Models.HospitalModel;

namespace Entity_Back.Models.SecurityModels
{
    public class Person : BaseModel
    {
        public string FullName { get; set; }
        public string FullLastName { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Document { get; set; }
        public DateTime DateBorn { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; } 
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public HealthRegime HealthRegime { get; set; }
        public User User { get; set; }
        public int EpsId { get; set; }
        public Eps Eps { get; set; }

        public List<RelatedPerson> RelatedPerson {  get; set; } = new List<RelatedPerson>();
        public List<Doctor> Doctor { get; set; } = new List<Doctor>();

    }
}
