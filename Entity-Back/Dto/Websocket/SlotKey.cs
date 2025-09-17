using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.Websocket
{
    public record SlotKey(int ScheduleHourId, DateTime Date, TimeSpan TimeBlock);
}
