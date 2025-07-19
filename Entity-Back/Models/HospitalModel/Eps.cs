using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Models.SecurityModels;

namespace Entity_Back.Models.HospitalModel
{
    public class Eps : BaseModel
    {
        public string Name { get; set; }
        public List<Person> Person {  get; set; }
    }
}
