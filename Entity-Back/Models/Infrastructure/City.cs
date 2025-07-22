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

    }
}
