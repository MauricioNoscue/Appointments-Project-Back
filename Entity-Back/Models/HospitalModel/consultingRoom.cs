using System.Collections.Generic;
using Entity_Back.Models;
using Entity_Back.Models.Infrastructure;

namespace Entity_Back
{
    public class ConsultingRoom : BaseModel
    {
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int BranchId { get; set; }
        public string? Image {  get; set; }
        public bool? IsActive { get; set; }
        public Branch Branch { get; set; }
        public  List<Shedule> Shedules { get; set; }
    }

}