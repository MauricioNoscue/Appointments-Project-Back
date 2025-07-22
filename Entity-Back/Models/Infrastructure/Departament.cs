using Entity_Back.Models.SecurityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Models.Infrastructure
{
    public class Departament:BaseModel
    {
        public string Name { get; set; }

        public List<City> Citys { get; set; } = new List<City>();
    }
}
