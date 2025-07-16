using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Models.Security;
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

        }
    }
}
