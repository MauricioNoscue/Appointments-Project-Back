using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Enum
{

    public enum CategoryStatus
    {
        [Description("Notification")]
        Notification,

        [Description("Request")]
        Request,

        [Description("Citation")]
        Citation,

    }
}
