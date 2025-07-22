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



        }
    }
}
