using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IBaseModelData;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Models.Security;

namespace Web_back.Extension
{
    public static  class ServiceExtensionsBussinesData
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {


            services.AddScoped<IRolData, RolData>();

            services.AddScoped<IBaseModelData<Rol>, RolData>();


            services.AddScoped<IRolData, RolData>();
            services.AddScoped<
                IBaseModelBusiness<RolCreatedDto, RolEditDto, RolListDto>,
                RolBusiness
            >();


            return services;
        }
    }
}
