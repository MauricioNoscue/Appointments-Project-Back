using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.SecurityDto.PersonDto;
using Entity_Back.Dto.SecurityDto.RolDto;
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

            TypeAdapterConfig<Rol, RolListDto>.NewConfig();
            TypeAdapterConfig<RolCreatedDto, Rol>.NewConfig();
            TypeAdapterConfig<RolEditDto, Rol>.NewConfig();




        
            TypeAdapterConfig<User, UserListDto>.NewConfig();

            TypeAdapterConfig<UserCreatedDto, User>.NewConfig()
            .Map(dest => dest.Person, src => src.Person)
             .Map(dest => dest.Active, src => src.Active);

            TypeAdapterConfig<UserEditDto, User>.NewConfig();



            TypeAdapterConfig<PersonCreatedDto, Person>.NewConfig();


            // Configuración para Person con conversión de enums
            TypeAdapterConfig<PersonCreatedDto, Person>.NewConfig()
                .Map(dest => dest.Gender, src => Enum.Parse<Gender>(src.Gender, true))
                .Map(dest => dest.HealthRegime, src => Enum.Parse<HealthRegime>(src.HealthRegime, true))
                .Map(dest => dest.Active, src => true)
                .Map(dest => dest.IsDeleted, src => false);







        }
    }
}
