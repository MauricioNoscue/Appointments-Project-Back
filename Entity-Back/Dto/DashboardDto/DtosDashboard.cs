using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Back.Dto.DashboardDto
{
    public class DoctorDashboardVmDto
    {
        public KpiDto Kpis { get; set; } = new();
        public WeeklyBarsDto WeeklyBars { get; set; } = new();
        public DonutDto Donut { get; set; } = new();
        public NextCitationDto? Next { get; set; }
        public int PendingCount { get; set; }
    }

    public class KpiDto
    {
        public int AttendedToday { get; set; }
        public int PresentToday { get; set; }
        public int AbsentToday { get; set; }
    }

    public class WeeklyBarsDto
    {
        public List<string> Labels { get; set; } = new();
        public List<int> Values { get; set; } = new();
    }

    public class DonutDto
    {
        public int Attended { get; set; }
        public int NotAttended { get; set; }
    }

    public class NextCitationDto
    {
        public DateTime Date { get; set; }
        public string TimeLabel { get; set; } = string.Empty;
        public string? Note { get; set; }
    }

}
