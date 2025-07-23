using Entity_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.InstitutionDto
{
    public class InstitutionListDto : BaseModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Nit { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
    }
}
