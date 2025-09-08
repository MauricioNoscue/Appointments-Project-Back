using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.HospitalDto.RelatedPerson
{
   public class RelatedPersonEditDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; } // PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relation { get; set; }
        public int DocumentTypeId { get; set; }
        public string Document { get; set; }
    }
}
