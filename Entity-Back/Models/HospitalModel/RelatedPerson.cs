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
        public string TypeRelation { get; set; }
        public string Description{ get; set; }

        public Person Person { get; set; }
    }
}
