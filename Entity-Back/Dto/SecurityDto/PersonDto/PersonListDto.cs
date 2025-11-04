using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models;

namespace Entity_Back.Dto.SecurityDto.PersonDto
{
    public class PersonListDto : BaseModel
    {
        public string FullName { get; set; }
        public string FullLastName { get; set; }
        public string DocumentTypeName { get; set; }
        public string DocumentTypeAcronymName { get; set; }
        public string Document { get; set; }
        public DateTime DateBorn { get; set; }
        public string PhoneNumber { get; set; }
        public string EpsName { get; set; }
        public int FailedAppointments { get; set; }
        public string Gender { get; set; }
        public string HealthRegime { get; set; }
        public string? Address { get; set; }

    }
}
