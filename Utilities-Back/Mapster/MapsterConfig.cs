using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back;
using Entity_Back.Dto.HospitalDto.RelatedPerson;
using Entity_Back.Dto.InfrastructureDto.BranchDto;
using Entity_Back.Dto.InfrastructureDto.CityDto;
using Entity_Back.Dto.InfrastructureDto.Departament;
using Entity_Back.Dto.InfrastructureDto.DepartamentDto;
using Entity_Back.Dto.InfrastructureDto.InstitutionDto;
using Entity_Back.Dto.Notification;
using Entity_Back.Dto.SecurityDto.FormDto;
using Entity_Back.Dto.SecurityDto.ModuleDto;
using Entity_Back.Dto.SecurityDto.PermissionDto;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Dto.SecurityDto.RolFormPermissionDto;
using Entity_Back.Dto.SecurityDto.RolUserDto;
using Entity_Back.Dto.SecurityDto.UserDto;
using Entity_Back.Enum;
using Entity_Back.Models.HospitalModel;
using Entity_Back.Models.Infrastructure;
using Entity_Back.Models.Notification;

using Entity_Back.Models.Security;
using Entity_Back.Models.SecurityModels;
using Mapster;

namespace Utilities_Back.Mapster
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            //Rol
            TypeAdapterConfig<Rol, RolListDto>.NewConfig();
            TypeAdapterConfig<RolCreatedDto, Rol>.NewConfig();
            TypeAdapterConfig<RolEditDto, Rol>.NewConfig();

            //User
            TypeAdapterConfig<User, UserListDto>.NewConfig().Map(des => des.PersonName, src => src.Person.FullName); ;
            TypeAdapterConfig<UserCreatedDto, User>.NewConfig();

            TypeAdapterConfig<UserEditDto, User>.NewConfig();

            //Person
            TypeAdapterConfig<PersonCreatedDto, Person>
            .NewConfig()
            .Map(dest => dest.Gender, src => Enum.Parse<Gender>(src.Gender, true))
            .Map(dest => dest.HealthRegime, src => Enum.Parse<HealthRegime>(src.HealthRegime, true));
            TypeAdapterConfig<Person, PersonListDto>
            .NewConfig()
            .Map(dest => dest.Gender, src => src.Gender.ToString())
             .Map(dest => dest.HealthRegime, src => src.HealthRegime.ToString());

            //RolUser
            TypeAdapterConfig<RolUserCreatedDto, RolUser>.NewConfig();
            TypeAdapterConfig<RolUser, RolUserList>.NewConfig()
                .Map(dest => dest.RolName, src => src.Rol.Name)
                .Map(dest => dest.Email, src => src.User.Email);
            TypeAdapterConfig<RolUserEditDto, RolUser>.NewConfig();

            //Permission
            TypeAdapterConfig<Permission, PermissionListDto>.NewConfig();
            TypeAdapterConfig<PermissionCreatedDto, Permission>.NewConfig();
            TypeAdapterConfig<PermissionEditDto, Permission>.NewConfig();

            //Module
            TypeAdapterConfig<Module, ModuleListDto>.NewConfig();
            TypeAdapterConfig<ModuleCreatedDto, Module>.NewConfig();
            TypeAdapterConfig<ModuleEditDto, Module>.NewConfig();

            //Form
            TypeAdapterConfig<Form, FormListDto>.NewConfig().Map(dest => dest.ModuloName, src => src.Module.Name);
            TypeAdapterConfig<FormCreatedDto, Form>.NewConfig();
            TypeAdapterConfig<FormEditDto, Form>.NewConfig();

            //roluser
            TypeAdapterConfig<RolUserCreatedDto, RolUser>.NewConfig();
            TypeAdapterConfig<RolUser, RolUserList>.NewConfig()
                .Map(dest => dest.RolName, src => src.Rol.Name)
                .Map(dest => dest.Email, src => src.User.Email);
            TypeAdapterConfig<RolUserEditDto, RolUser>.NewConfig();


            //RolFormPermission
            TypeAdapterConfig<RolFormPermissionCreatedDto, RolFormPermission>.NewConfig();
            TypeAdapterConfig<RolFormPermission, RolFormPermissionListDto>.NewConfig()
                .Map(dest => dest.RolName, src => src.Rol.Name)
                .Map(dest => dest.FormName, src => src.Form.Name)
                .Map(dest => dest.PermissionName, src => src.Permission.Name);
            TypeAdapterConfig<RolFormPermissionEditDto, RolFormPermission>.NewConfig();


            TypeAdapterConfig<Person, PersonListDto>.NewConfig()
                .Map(des => des.DocumentTypeName, src => src.DocumentType.Name)
                .Map(des => des.DocumentTypeAcronymName, src => src.DocumentType.Acronym)
                .Map(des => des.EpsName, src => src.Eps.Name);
            TypeAdapterConfig<PersonCreatedDto, Person>.NewConfig();
            TypeAdapterConfig<PersonEditDto, Person>.NewConfig();




            // Citation
            TypeAdapterConfig<CitationCreateDto, Citation>.NewConfig()
                .Map(dest => dest.Note, src => src.Note)
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.ScheduleHourId, src => src.ScheduleHourId);

            TypeAdapterConfig<CitationEditDto, Citation>
                .NewConfig()
                .IgnoreNullValues(true)
                .Map(d => d.State, s => s.State)
                .Map(d => d.Note, s => s.Note);

            TypeAdapterConfig<Citation, CitationListDto>.NewConfig()
                .Map(dest => dest.State, src => src.State)
                .Map(dest => dest.Note, src => src.Note)
                .Map(dest => dest.AppointmentDate, src => src.AppointmentDate)

                .Map(dest => dest.NameDoctor, src => src.ScheduleHour.Shedule.Doctor.Person.FullName)  // ajusta si tu Doctor no tiene Person
                .Map(dest => dest.ConsultingRoomName, src => src.ScheduleHour.Shedule.ConsultingRoom.Name)
                .Map(dest => dest.RoomNumber, src => src.ScheduleHour.Shedule.ConsultingRoom.RoomNumber);

            // ScheduleHour
            TypeAdapterConfig<ScheduleHourCreateDto, ScheduleHour>.NewConfig()
                .Map(dest => dest.StartTime, src => src.StartTime)
                .Map(dest => dest.EndTime, src => src.EndTime)
                .Map(dest => dest.ProgramateDate, src => src.ProgramateDate)
                .Map(dest => dest.SheduleId, src => src.SheduleId);

            TypeAdapterConfig<ScheduleHourEditDto, ScheduleHour>.NewConfig()
                .Map(dest => dest.StartTime, src => src.StartTime)
                .Map(dest => dest.EndTime, src => src.EndTime)
                .Map(dest => dest.ProgramateDate, src => src.ProgramateDate);

            TypeAdapterConfig<ScheduleHour, ScheduleHourListDto>.NewConfig()
                .Map(dest => dest.StartTime, src => src.StartTime)
                .Map(dest => dest.EndTime, src => src.EndTime)
                .Map(dest => dest.ProgramateDate, src => src.ProgramateDate);

            // ConsultingRoom
            TypeAdapterConfig<ConsultingRoomCreateDto, ConsultingRoom>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.RoomNumber, src => src.RoomNumber)
                .Map(dest => dest.Floor, src => src.Floor)
                .Map(dest => dest.BranchId, src => src.BranchId);

            TypeAdapterConfig<ConsultingRoomEditDto, ConsultingRoom>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.RoomNumber, src => src.RoomNumber)
                .Map(dest => dest.Floor, src => src.Floor);

            TypeAdapterConfig<ConsultingRoom, ConsultingRoomListDto>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.RoomNumber, src => src.RoomNumber)
                .Map(dest => dest.Floor, src => src.Floor);

            // Doctor
            TypeAdapterConfig<DoctorCreateDto, Doctor>.NewConfig()
                .Map(dest => dest.SpecialtyId, src => src.SpecialtyId)
                .Map(dest => dest.Active, src => src.Active)
                .Map(dest => dest.Image, src => src.Image)
                .Map(dest => dest.EmailDoctor, src => src.EmailDoctor);


            TypeAdapterConfig<DoctorEditDto, Doctor>.NewConfig()
                .Map(dest => dest.SpecialtyId, src => src.SpecialtyId)

                .Map(dest => dest.Image, src => src.Image)
                .Map(dest => dest.EmailDoctor, src => src.EmailDoctor);

            TypeAdapterConfig<Doctor, DoctorListDto>.NewConfig()
                .Map(dest => dest.SpecialtyName, src => src.Specialty.Name)
                .Map(dest => dest.Active, src => src.Active)
                .Map(dest => dest.Image, src => src.Image)
                .Map(dest => dest.EmailDoctor, src => src.EmailDoctor)
                .Map(dest => dest.FullName, src => src.Person.FullName);

            // TypeCitation
            TypeAdapterConfig<TypeCitationCreateDto, TypeCitation>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Icon, src => src.Icon);

            TypeAdapterConfig<TypeCitationEditDto, TypeCitation>.NewConfig()
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Icon, src => src.Icon);

            TypeAdapterConfig<TypeCitation, TypeCitationListDto>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Icon, src => src.Icon);

            // Shedule
            TypeAdapterConfig<SheduleCreateDto, Shedule>.NewConfig()
                .Map(dest => dest.TypeCitationId, src => src.TypeCitationId)
                .Map(dest => dest.DoctorId, src => src.DoctorId)
                .Map(dest => dest.ConsultingRoomId, src => src.ConsultingRoomId)
                .Map(dest => dest.NumberCitation, src => src.NumberCitation);

            TypeAdapterConfig<SheduleEditDto, Shedule>.NewConfig()
                .Map(dest => dest.TypeCitationId, src => src.TypeCitationId)
                .Map(dest => dest.DoctorId, src => src.DoctorId)
                .Map(dest => dest.ConsultingRoomId, src => src.ConsultingRoomId)
                .Map(dest => dest.NumberCitation, src => src.NumberCitation);

            TypeAdapterConfig<Shedule, SheduleListDto>.NewConfig()
                .Map(dest => dest.TypeCitationName, src => src.TypeCitation.Name)
                .Map(dest => dest.NameDoctor, src => src.Doctor.Person.FullName)
                .Map(dest => dest.ConsultingRoomName, src => src.ConsultingRoom.Name)
                .Map(dest => dest.NumberCitation, src => src.NumberCitation)
                .Map(dest => dest.RoomNumber, src => src.ConsultingRoom.RoomNumber);

            TypeAdapterConfig<RelatedPersonCreatedDto, RelatedPerson>
                .NewConfig()
                .Map(d => d.PersonId, s => s.PersonId)
                .Map(d => d.FirstName, s => s.FirstName)
                .Map(d => d.LastName, s => s.LastName)
                .Map(d => d.Relation, s => s.Relation)
                .Map(d => d.DocumentTypeId, s => s.DocumentTypeId)
                .Map(d => d.Document, s => s.Document)
                .IgnoreNullValues(true);
            
            // RelatedPerson (Edit -> Entity)
            TypeAdapterConfig<RelatedPersonEditDto, RelatedPerson>
                .NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.FirstName, s => s.FirstName)
                .Map(d => d.LastName, s => s.LastName)
                .Map(d => d.Relation, s => s.Relation)
                .Map(d => d.DocumentTypeId, s => s.DocumentTypeId)
                .Map(d => d.Document, s => s.Document)
                .Ignore(d => d.PersonId)
                .IgnoreNullValues(true);

            // RelatedPerson (Entity -> List)
            TypeAdapterConfig<RelatedPerson, RelatedPersonListDto>
                .NewConfig()
                .Map(d => d.PersonId, s => s.PersonId)
                .Map(d => d.FullName, s => s.FirstName + " " + s.LastName)
                .Map(d => d.Relation, s => s.Relation)
              // Usa Acronym si lo tienes (como en Person), si no existe usa Name.
                .Map(d => d.DocumentTypeName, s => s.DocumentType != null ? s.DocumentType.Acronym : null)
                .Map(d => d.Document, s => s.Document);

            //Infrastructure
            //Branch
            TypeAdapterConfig<BranchCreatedDto, Branch>.NewConfig();
            TypeAdapterConfig<Branch, BranchListDto>.NewConfig()
                .Map(dest => dest.InstitutionName, src => src.Institution.Name);
            TypeAdapterConfig<BranchEditDto, Branch>.NewConfig();

            //City
            TypeAdapterConfig<CityCreatedDto, City>.NewConfig();
            TypeAdapterConfig<City, CityListDto>.NewConfig()
                .Map(dest => dest.DepartamentName, src => src.Departament.Name);
            TypeAdapterConfig<CityEditDto, City>.NewConfig();

            //Departament
            TypeAdapterConfig<DepartamentCreatedDto, Departament>.NewConfig();
            TypeAdapterConfig<Departament, DepartamentListDto>.NewConfig();
            TypeAdapterConfig<DepartamentEditDto, Departament>.NewConfig();

            //Institution
            TypeAdapterConfig<InstitutionCreatedDto, Institution>.NewConfig();
            TypeAdapterConfig<Institution, InstitutionListDto>.NewConfig()
                .Map(dest => dest.CityName, src => src.City.Name);
            TypeAdapterConfig<InstitutionEditDto, Institution>.NewConfig();

            //Notification
            // Notification (Create -> Entity, ya lo tienes)
            TypeAdapterConfig<NotificationCreateDto, Notification>
                .NewConfig()
                .Map(d => d.StateNotification, s => s.StateNotification ?? false);

            // Notification (Entity -> List, ya lo tienes)
            TypeAdapterConfig<Notification, NotificationListDto>.NewConfig()
                .Map(d => d.TypeCitationName, s => s.citation.ScheduleHour.Shedule.TypeCitation.Name);

            // ⬇️  DESCOMENTAR / AÑADIR  ⬇️
            TypeAdapterConfig<NotificationEditDto, Notification>
                .NewConfig()
                .IgnoreNullValues(true); // solo ignora null; false SÍ se aplica


        }
    }
}
