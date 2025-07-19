using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;

namespace Entity_Back.Models.HospitalModel
{
    public class DocumentType  : BaseModel
    {
        public string Name { get; set; }
        public string Acronym { get; set; }
        public List<Person> Person { get; set; }
    }
}
