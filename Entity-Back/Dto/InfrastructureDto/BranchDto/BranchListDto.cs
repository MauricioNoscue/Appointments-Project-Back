using Entity_Back.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.InfrastructureDto.BranchDto
{
    public class BranchListDto : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; } 
        

    }
}
