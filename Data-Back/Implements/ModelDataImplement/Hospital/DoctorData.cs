using System.Collections.Generic;
using Data_Back.Implements.BaseModelData;
using Data_Back.Interface;
using Entity_Back;
using Entity_Back.Context;
using Entity_Back.Dto.HospitalDto.DoctorDto;
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
                    .Include(d => d.Specialty)
                    .Where(d => d.PersonId == id && !d.IsDeleted)
                    .FirstOrDefaultAsync();

                if (doctor == null) return null;

                return new DoctorListDto
                {
                    Id = doctor.Id,
                    IsDeleted = doctor.IsDeleted,
                    RegistrationDate = doctor.RegistrationDate,
                    SpecialtyName = doctor.Specialty?.Name ?? string.Empty,
                    Active = doctor.Active,
                    Image = doctor.Image,
                    FullName = doctor.Person?.FullName,
                    EmailDoctor = doctor.EmailDoctor,
                    PersonId = doctor.PersonId
                };
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
                    .Include(d => d.Specialty)
                    .Where(d => !d.IsDeleted)
                    .ToListAsync();

                return doctors.Select(d => new DoctorListDto
                {
                    Id = d.Id,
                    IsDeleted = d.IsDeleted,
                    RegistrationDate = d.RegistrationDate,
                    SpecialtyName = d.Specialty?.Name ?? string.Empty,
                    Active = d.Active,
                    Image = d.Image,
                    FullName = d.Person?.FullName,
                    EmailDoctor = d.EmailDoctor,
                    PersonId = d.PersonId
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los doctores: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene todas las citas asignadas a un doctor específico siguiendo la relación:
        /// Citation -> ScheduleHour -> Shedule -> Doctor
        /// Incluye información del paciente (User -> Person)
        /// </summary>
        /// <param name="doctorId">ID del doctor</param>
        /// <returns>Lista de citas del doctor</returns>
        public async Task<IEnumerable<CitationListDto>> GetCitationsByDoctorId(int doctorId)
        {
            try
            {
                var citations = await _context.Citation
                    .Include(c => c.User)
                        .ThenInclude(u => u.Person)
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
                        StatustypesId = c.StatustypesId,
                        Note = c.Note,
                        AppointmentDate = c.AppointmentDate,
                        TimeBlock = c.TimeBlock,
                        ScheduleHourId = c.ScheduleHourId,
                        NameDoctor = c.ScheduleHour.Shedule.Doctor.Person.FullName + " " + c.ScheduleHour.Shedule.Doctor.Person.FullLastName,
                        ConsultingRoomName = c.ScheduleHour.Shedule.ConsultingRoom.Name,
                        RoomNumber = c.ScheduleHour.Shedule.ConsultingRoom.RoomNumber,
                        PatientName = c.User.Person.FullName + " " + c.User.Person.FullLastName,
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

        public async Task<Doctor?> GetDoctorByUserIdAsync(int userId)
        {
            try
            {
                return await _context.Doctors
                    .AsNoTracking()
                    .FirstOrDefaultAsync(d => d.Person.User.Id == userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el Doctor asociado al UserId {userId}");
                throw;
            }
        }


        public async Task<DoctorReviewAll?> GetDoctorWithReviewsAsync(int doctorId)
        {
            try
            {
                var doctor = await _context.Doctors
                    .AsNoTracking()
                    .Include(d => d.Person)          // Persona asociada
                    .Include(d => d.Specialty)       // Especialidad
                    .Include(d => d.Reviews)         // Lista de reseñas
                    .Where(d => d.Id == doctorId && !d.IsDeleted)
                    .FirstOrDefaultAsync();

                if (doctor == null)
                    return null;

                // Adaptación al DTO final
                return doctor.Adapt<DoctorReviewAll>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener Doctor con Reviews. DoctorId: {doctorId}");
                throw;
            }
        }





    }
}
