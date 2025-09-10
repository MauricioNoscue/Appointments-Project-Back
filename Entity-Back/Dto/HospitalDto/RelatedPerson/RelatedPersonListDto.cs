using Entity_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.HospitalDto.RelatedPerson
{
    public class RelatedPersonListDto: BaseModel
    {
        public int PersonId { get; set; }
        public string FullName { get; set; }     // $"{FirstName} {LastName}"
        public string Relation { get; set; }
        public string DocumentTypeName { get; set; }
        public string Document { get; set; }
    }
}
