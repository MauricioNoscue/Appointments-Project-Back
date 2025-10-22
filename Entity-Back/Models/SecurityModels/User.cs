﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.Notification;
using Entity_Back.Models.Notification;

namespace Entity_Back.Models.SecurityModels
{
    public class User: BaseModel
    {

        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Active { get; set; } = false;
        public int? PersonId { get; set; }
        public string? CodePassword { get; set; }
        public int? RestrictionPoint { get; set; }
        public string? PasswordResetToken { get; set; }

        public DateTime? PasswordResetTokenExpiration { get; set; }
        public Person Person { get; set; }
        public List<Notifications> Notifications { get; set; } = new List<Notifications>();
        public List<Citation> Citation { get; set; }

        public List<RolUser> RolUser { get; set; } = new List<RolUser>();
    }
}
