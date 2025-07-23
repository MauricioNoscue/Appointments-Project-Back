using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.CityDto
{
    public class CityEditDto
    {
        public int Id { get; set; }
        public int DepartamentId { get; set; }
        public string Name { get; set; }
    }
}
