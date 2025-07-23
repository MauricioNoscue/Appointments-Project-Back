using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back;
using Entity_Back.Dto.SecurityDto.ModuleDto;
using Entity_Back.Dto.SecurityDto.PermissionDto;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Dto.SecurityDto.RolFormPermissionDto;
using Entity_Back.Dto.SecurityDto.RolUserDto;
using Entity_Back.Dto.SecurityDto.UserDto;
using Entity_Back.Enum;
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
            TypeAdapterConfig<User, UserListDto>.NewConfig();
            TypeAdapterConfig<UserCreatedDto, User>.NewConfig()
            .Map(dest => dest.Person, src => src.Person)
             .Map(dest => dest.Active, src => src.Active);
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
            TypeAdapterConfig<Module, ModuleListDto>.NewConfig();
            TypeAdapterConfig<ModuleCreatedDto, Module>.NewConfig();
            TypeAdapterConfig<ModuleEditDto, Module>.NewConfig();

            //FormModule
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


            // Citation
            TypeAdapterConfig<CitationCreateDto, Citation>.NewConfig()
                .Map(dest => dest.Note, src => src.Note)
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest.ScheduleHourId, src => src.ScheduleHourId);

            TypeAdapterConfig<CitationEditDto, Citation>.NewConfig()
                .Map(dest => dest.State, src => src.State)
                .Map(dest => dest.Note, src => src.Note);

            TypeAdapterConfig<Citation, CitationListDto>.NewConfig()
                .Map(dest => dest.State, src => src.State)
                .Map(dest => dest.Note, src => src.Note)
                .Map(dest => dest.CreationDate, src => src.CreationDate);

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
                .Map(dest => dest.Specialty, src => src.Specialty)
                .Map(dest => dest.IdUser, src => src.IdUser)
                .Map(dest => dest.Active, src => src.Active)
                .Map(dest => dest.Image, src => src.Image);

            TypeAdapterConfig<DoctorEditDto, Doctor>.NewConfig()
                .Map(dest => dest.Specialty, src => src.Specialty)
                .Map(dest => dest.IdUser, src => src.IdUser)
                .Map(dest => dest.Active, src => src.Active)
                .Map(dest => dest.Image, src => src.Image);

            TypeAdapterConfig<Doctor, DoctorListDto>.NewConfig()
                .Map(dest => dest.Specialty, src => src.Specialty)
                .Map(dest => dest.Active, src => src.Active)
                .Map(dest => dest.Image, src => src.Image)
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
                .Map(dest => dest.NumberCitation, src => src.NumberCitation)
                .Map(dest => dest.SheduleId, src => src.SheduleId);

            TypeAdapterConfig<SheduleEditDto, Shedule>.NewConfig()
                .Map(dest => dest.TypeCitationId, src => src.TypeCitationId)
                .Map(dest => dest.DoctorId, src => src.DoctorId)
                .Map(dest => dest.ConsultingRoomId, src => src.ConsultingRoomId)
                .Map(dest => dest.NumberCitation, src => src.NumberCitation)
                .Map(dest => dest.SheduleId, src => src.SheduleId);

            TypeAdapterConfig<Shedule, SheduleListDto>.NewConfig()
                .Map(dest => dest.TypeCitationId, src => src.TypeCitationId)
                .Map(dest => dest.NameDoctor, src => src.Doctor.Person.FullName)
                .Map(dest => dest.ConsultingRoomId, src => src.ConsultingRoomId)
                .Map(dest => dest.NumberCitation, src => src.NumberCitation)
                .Map(dest => dest.SheduleId, src => src.SheduleId);





        }
    }
}
