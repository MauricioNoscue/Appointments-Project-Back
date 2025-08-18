using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back;
using Mapster;

namespace Business_Back.Services.Citation
{
    public class CitationCoreService
    {
        private readonly IScheduleHourBusiness _scheduleHourBusiness;
        private readonly ISheduleBusiness _sheduleBusiness;
        private readonly ICitationsBusiness _citationBusiness;
        public CitationCoreService(IScheduleHourBusiness scheduleHourBusiness, ISheduleBusiness sheduleBusiness,ICitationsBusiness citationBusiness)
        {
            _scheduleHourBusiness = scheduleHourBusiness;
            _sheduleBusiness = sheduleBusiness;
            _citationBusiness = citationBusiness;
        }


        public async Task<List<TimeSpan>> GetAvailableTimeBlocksByTypeCitationIdAsync(int typeCitationId, DateTime fecha)
        {
            try
            {
                // Paso 1: Obtener el Shedule por tipo de cita
                var shedule = await _sheduleBusiness.GetByIdTypeCitation(typeCitationId);
                if (shedule == null)
                    throw new Exception("No se encontró un horario (Shedule) para el tipo de cita.");

                // Paso 2: Obtener el ScheduleHour asociado al Shedule (sin fecha)
                var scheduleHour = await _scheduleHourBusiness.GetByDateAndSheduleAsync(shedule.Id);
                if (scheduleHour == null)
                    throw new Exception("No se encontró configuración horaria para el tipo de cita.");

                // Paso 3: Mapear a entidad y unir el Shedule
                var scheduleHourEntity = scheduleHour.Adapt<ScheduleHour>();
                scheduleHourEntity.Shedule = shedule.Adapt<Shedule>();

                // Paso 4: Generar los bloques posibles
                var todosLosBloques = CalcularBloquesHorarios(scheduleHourEntity);

                // Paso 5: Consultar citas ya agendadas en esa fecha
                var bloquesOcupados = await _citationBusiness
                    .GetUsedTimeBlocksByScheduleHourIdAndDateAsync(scheduleHourEntity.Id, fecha.Date);

                // Paso 6: Filtrar los bloques disponibles
                var disponibles = FiltrarBloquesDisponibles(todosLosBloques, bloquesOcupados);

                return disponibles;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener bloques horarios disponibles: {ex.Message}", ex);
            }
        }


        public List<TimeSpan> CalcularBloquesHorarios(ScheduleHour scheduleHour)
        {
            var bloques = new List<TimeSpan>();

            if (scheduleHour == null || scheduleHour.Shedule == null || scheduleHour.Shedule.NumberCitation <= 0)
                return bloques;

            int cantidadCitas = scheduleHour.Shedule.NumberCitation;
            TimeSpan horaInicio = scheduleHour.StartTime;
            TimeSpan horaFin = scheduleHour.EndTime;

            TimeSpan? pausaInicio = scheduleHour.BreakStartTime;
            TimeSpan? pausaFin = scheduleHour.BreakEndTime;

            TimeSpan duracionDisponible = pausaInicio.HasValue && pausaFin.HasValue
                ? (pausaInicio.Value - horaInicio) + (horaFin - pausaFin.Value)
                : horaFin - horaInicio;

            TimeSpan duracionCita = TimeSpan.FromMinutes(duracionDisponible.TotalMinutes / cantidadCitas);
            TimeSpan actual = horaInicio;

            for (int i = 0; i < cantidadCitas; i++)
            {
                if (pausaInicio.HasValue && pausaFin.HasValue &&
                    actual >= pausaInicio.Value && actual < pausaFin.Value)
                {
                    actual = pausaFin.Value;
                }

                if (actual + duracionCita <= horaFin)
                {
                    bloques.Add(actual);
                    actual = actual.Add(duracionCita);
                }
                else
                {
                    break;
                }
            }

            return bloques;
        }

        public List<TimeSpan> FiltrarBloquesDisponibles(List<TimeSpan> todosLosBloques, List<TimeSpan> bloquesOcupados)
        {
            return todosLosBloques
                .Where(b => !bloquesOcupados.Contains(b))
                .ToList();
        }

    }
}
