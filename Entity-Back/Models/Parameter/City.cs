using Entity_Back.Models.SecurityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Models.Infrastructure
{
    public class City:BaseModel
    {
        public int DepartamentId { get; set; }
        public string Name { get; set; }
        public Departament Departament { get; set; }
        public List<Institution> Institutions { get; set; } = new List<Institution>();
    }
}
