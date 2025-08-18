using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.HospitalDto.Citation
{
    public class TimeBlockEstado
    {
        public TimeSpan Hora { get; set; }
        public bool EstaDisponible { get; set; }
    }

}
