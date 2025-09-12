using System.Collections.Generic;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Entity_Back.Models.SecurityModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data_Back.Implements
{
    public class DoctorData : BaseModelData<Doctor>, IDoctorData
    {
        public readonly ApplicationDbContext _context;
        public DoctorData(ApplicationDbContext context, ILogger<BaseModelData<Doctor>> logger)
            : base(context, logger)
        {
            _context = context;
        }

        public async Task<DoctorListDto?> GetDoctorWithPersonById(int id)
        {
            try
            {
                var doctor = await _context.Doctors
                    .Include(d => d.Person)
                    .Where(d => d.Id == id && !d.IsDeleted)
                    .FirstOrDefaultAsync();

                return doctor?.Adapt<DoctorListDto>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el doctor por PersonId {id}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<DoctorListDto>> GetAllDoctorWithPerson()
        {
            try
            {
                var doctors = await _context.Doctors
                    .Include(d => d.Person)
                    .Where(d => !d.IsDeleted)
                    .ToListAsync();

                return doctors.Adapt<IEnumerable<DoctorListDto>>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los doctores: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene todas las citas asignadas a un doctor específico siguiendo la relación:
        /// Citation -> ScheduleHour -> Shedule -> Doctor
        /// </summary>
        /// <param name="doctorId">ID del doctor</param>
        /// <returns>Lista de citas del doctor</returns>
        public async Task<IEnumerable<CitationListDto>> GetCitationsByDoctorId(int doctorId)
        {
            try
            {
                var citations = await _context.Citation
                    .Include(c => c.ScheduleHour)
                        .ThenInclude(sh => sh.Shedule)
                            .ThenInclude(s => s.Doctor)
                                .ThenInclude(d => d.Person)
                    .Include(c => c.ScheduleHour)
                        .ThenInclude(sh => sh.Shedule)
                            .ThenInclude(s => s.ConsultingRoom)
                    .Where(c => c.ScheduleHour.Shedule.DoctorId == doctorId && !c.IsDeleted)
                    .Select(c => new CitationListDto
                    {
                        Id = c.Id,
                        State = c.State,
                        Note = c.Note,
                        AppointmentDate = c.AppointmentDate,
                        TimeBlock = c.TimeBlock,
                        ScheduleHourId = c.ScheduleHourId,
                        NameDoctor = c.ScheduleHour.Shedule.Doctor.Person.FullName + " " + c.ScheduleHour.Shedule.Doctor.Person.FullLastName,
                        ConsultingRoomName = c.ScheduleHour.Shedule.ConsultingRoom.Name,
                        RoomNumber = c.ScheduleHour.Shedule.ConsultingRoom.RoomNumber,
                        RegistrationDate = c.RegistrationDate
                    })
                    .ToListAsync();

                return citations;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las citas del doctor {doctorId}: {ex.Message}", ex);
            }
        }
    }
}
