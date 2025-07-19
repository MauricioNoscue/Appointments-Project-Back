using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.SecurityDto.PersonDto
{
    public class PersonCreatedDto
    {
        public string FullName { get; set; }
        public string FullLastName { get; set; }
        public int DocumentTypeId { get; set; }
        public string Document { get; set; }
        public DateTime DateBorn { get; set; }
        public string PhoneNumber { get; set; }
        public string EpsName { get; set; }
        public int EpsId { get; set; }
        public string Gender { get; set; }
        public string HealthRegime { get; set; }
    }
}
