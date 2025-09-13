using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;

namespace Entity_Back.Models.HospitalModel
{
    public class RelatedPerson : BaseModel
    {

        public int PersonId { get; set; }
        public string FirstName { get; set; }   // Nombre
        public string LastName { get; set; }    // Apellido
        public string Relation { get; set; }    // Madre, Hijo, Primo...
        public int DocumentTypeId { get; set; } // FK a DocumentType (ya existe en Person)
        public string Document { get; set; }    // Número de documento
        public bool Active { get; set; } = true;
        public Person Person { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
