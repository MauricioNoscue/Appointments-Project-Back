using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Enum;
using Entity_Back.Models.SecurityModels;

namespace Entity_Back.Models.Notification
{ 
    // entidad nueva para las notificaciones para los usuarios registrados en la plataforma
    public class Notifications : BaseModel
    {
        public string Title { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public StatusNotification StateNotification { get; set; }
        public TypeNotification TypeNotification { get; set; }
        public Citation? citation { get; set; }
        public User User { get; set; } 
        public string? RedirectUrl { get; set; }

    }
}
