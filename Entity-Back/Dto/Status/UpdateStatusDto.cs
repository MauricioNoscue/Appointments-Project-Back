using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Status
{
    public class UpdateStatusDto
    {
        public int Id { get; set; }             // ID de la entidad
        public int Value { get; set; }          // Nuevo StatusTypesId
        public string Entity { get; set; } = ""; // Nombre de la entidad
    }
}
