using Business_Back.Interface.IBusinessModel.Dashboard;
using Entity_Back;
using Entity_Back.Context;
using Entity_Back.Dto.DashboardDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Business_Back.Implements.ModelBusinessImplements.Dashboard
{
    public class DashboardBusiness : IDashboardBusiness
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DashboardBusiness> _logger;

        public DashboardBusiness(ApplicationDbContext context, ILogger<DashboardBusiness> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<DashboardDto> GetDashboardDataAsync()
        {
            try
            {
                var now = DateTime.Now;
                var today = now.Date;
                var weekAgo = today.AddDays(-7);
                var monthAgo = today.AddDays(-30);

                // Citas
                var citasQuery = _context.Citation
                    .Include(c => c.ScheduleHour).ThenInclude(sh => sh.Shedule).ThenInclude(s => s.Doctor).ThenInclude(d => d.Specialty)
                    .AsQueryable();
               
           

                var totalCitasDia = await citasQuery.Where(c => c.AppointmentDate.Date == today).CountAsync();
                var totalCitasSemana = await citasQuery.Where(c => c.AppointmentDate >= weekAgo).CountAsync();
                var totalCitasMes = await citasQuery.Where(c => c.AppointmentDate >= monthAgo).CountAsync();

                var distribucionPorEspecialidad = await citasQuery
                    .Where(c => c.AppointmentDate >= monthAgo)
                    .GroupBy(c => c.ScheduleHour.Shedule.Doctor.Specialty.Name)
                    .ToDictionaryAsync(g => g.Key, g => g.Count());

                var estadosCitas = await citasQuery
                    .Where(c => c.AppointmentDate >= monthAgo)
                    .GroupBy(c => c.StatustypesId)
                    .ToDictionaryAsync(g => g.Key, g => g.Count());

               

                var citasDto = new CitasDto
                {
                    TotalCitasDia = totalCitasDia,
                    TotalCitasSemana = totalCitasSemana,
                    TotalCitasMes = totalCitasMes,
                    DistribucionPorEspecialidad = distribucionPorEspecialidad,
                    EstadosCitas = estadosCitas
                };

                // Pacientes
                var pacientesActivos = await _context.Person.Where(p => p.Active).CountAsync();
                var pacientesInactivos = await _context.Person.Where(p => !p.Active).CountAsync();

                var nuevosRegistrados = await _context.Person
                    .Where(p => p.RegistrationDate.HasValue && p.RegistrationDate >= monthAgo)
                    .GroupBy(p => p.RegistrationDate.Value.Date)
                    .Select(g => new NuevosPacientesDto { Fecha = g.Key, Cantidad = g.Count() })
                    .OrderBy(n => n.Fecha)
                    .ToListAsync();

                var pacientesDto = new PacientesDto
                {
                    PacientesActivos = pacientesActivos,
                    PacientesInactivos = pacientesInactivos,
                    NuevosRegistrados = nuevosRegistrados
                };

                // Doctores
                var topDoctores = await citasQuery
                    .Where(c => c.StatustypesId == 4)
                    .GroupBy(c => c.ScheduleHour.Shedule.Doctor.Person.FullName)
                    .Select(g => new TopDoctoresDto { NombreDoctor = g.Key, CitasAtendidas = g.Count() })
                    .OrderByDescending(t => t.CitasAtendidas)
                    .Take(5)
                    .ToListAsync();

                var doctoresDisponibles = await _context.ScheduleHours
                    .Include(sh => sh.Shedule).ThenInclude(s => s.Doctor).ThenInclude(d => d.Person)
                    .Where(sh => sh.ProgramateDate >= today && !sh.Citations.Any())
                    .GroupBy(sh => sh.Shedule.Doctor.Person.FullName)
                    .Select(g => new DoctoresDisponiblesDto { NombreDoctor = g.Key, CuposLibres = g.Count() })
                    .ToListAsync();

                var rankingEspecialidades = await citasQuery
                    .Where(c => c.AppointmentDate >= monthAgo)
                    .GroupBy(c => c.ScheduleHour.Shedule.Doctor.Specialty.Name)
                    .ToDictionaryAsync(g => g.Key, g => g.Count());

                var doctoresDto = new DoctoresDto
                {
                    TopDoctores = topDoctores,
                    DoctoresDisponibles = doctoresDisponibles,
                    RankingEspecialidades = rankingEspecialidades
                };

                // KPIs
                var totalCitasProgramadas = await citasQuery.Where(c => c.AppointmentDate >= monthAgo).CountAsync();
                var citasAtendidas = await citasQuery.Where(c => c.StatustypesId == 4 && c.AppointmentDate >= monthAgo).CountAsync();
                var tasaAsistencia = totalCitasProgramadas > 0 ? (double)citasAtendidas / totalCitasProgramadas * 100 : 0;

                var tiemposEspera = await citasQuery
                    .Where(c => c.StatustypesId == 4 && c.RegistrationDate.HasValue)
                    .Select(c => (c.AppointmentDate - c.RegistrationDate.Value).TotalHours)
                    .ToListAsync();
                var tiempoPromedioEspera = tiemposEspera.Any() ? tiemposEspera.Average() : 0;

                var kpisDto = new KpisDto
                {
                    TasaAsistencia = tasaAsistencia,
                    TiempoPromedioEspera = tiempoPromedioEspera
                };

                return new DashboardDto
                {
                    Citas = citasDto,
                    Pacientes = pacientesDto,
                    Doctores = doctoresDto,
                    Kpis = kpisDto
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener datos del dashboard");
                throw;
            }
        }
    }
}