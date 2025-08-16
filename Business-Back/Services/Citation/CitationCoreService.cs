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
        public CitationCoreService(IScheduleHourBusiness scheduleHourBusiness, ISheduleBusiness sheduleBusiness)
        {
            _scheduleHourBusiness = scheduleHourBusiness;
            _sheduleBusiness = sheduleBusiness;
        }


        public async Task<List<TimeSpan>> GetAvailableTimeBlocksByTypeCitationIdAsync(int typeCitationId)
        {
            try
            {
                // Paso 1: Obtener el Schedule (configuración general)
                var shedule = await _sheduleBusiness.GetByIdTypeCitation(typeCitationId);
                if (shedule == null)
                    throw new Exception("No se encontró un horario (Shedule) para el tipo de cita.");

                // Paso 2: Obtener el ScheduleHour (configuración del día)
                var scheduleHour = await _scheduleHourBusiness.GetByIdShedule(shedule.Id);
                if (scheduleHour == null)
                    throw new Exception("No se encontró una configuración horaria (ScheduleHour) para este horario.");

                // Paso 3: Mapear de DTO a entidad si lo necesitas (porque CalcularBloquesHorarios espera entidad)
                var scheduleHourEntity = scheduleHour.Adapt<ScheduleHour>();

                // Inyectar el Schedule dentro del objeto, ya que viene como entidad separada
                scheduleHourEntity.Shedule = shedule.Adapt<Shedule>();

                // Paso 4: Calcular bloques horarios
                var bloques = CalcularBloquesHorarios(scheduleHourEntity);

                return bloques;
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

            // Definir la duración efectiva (excluyendo la pausa)
            TimeSpan? pausaInicio = scheduleHour.BreakStartTime;
            TimeSpan? pausaFin = scheduleHour.BreakEndTime;
            TimeSpan duracionDisponible;

            if (pausaInicio.HasValue && pausaFin.HasValue)
                duracionDisponible = (pausaInicio.Value - horaInicio) + (horaFin - pausaFin.Value);
            else
                duracionDisponible = horaFin - horaInicio;

            // Calcular duración de cada cita (ajustada)
            TimeSpan duracionCita = TimeSpan.FromMinutes(duracionDisponible.TotalMinutes / cantidadCitas);

            TimeSpan actual = horaInicio;

            for (int i = 0; i < cantidadCitas; i++)
            {
                // Si la hora actual cae en la pausa, saltarla
                if (pausaInicio.HasValue && pausaFin.HasValue)
                {
                    if (actual >= pausaInicio.Value && actual < pausaFin.Value)
                    {
                        actual = pausaFin.Value;
                    }
                }

                // Validar que el bloque no se pase del horario
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

    }
}
