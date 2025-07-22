using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.InstitutionDto
{
    public class InstitutionCreatedDto
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Nit { get; set; }
        public string Email { get; set; }
    }
}
