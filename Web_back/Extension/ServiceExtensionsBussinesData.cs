using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IBaseModelData;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Dto.SecurityDto.UserDto;
using Entity_Back.Models.Security;
using Entity_Back.Models.SecurityModels;

namespace Web_back.Extension
{
    public static  class ServiceExtensionsBussinesData
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {


            services.AddScoped<IRolData, RolData>();
            services.AddScoped<IBaseModelData<Rol>, RolData>();


            services.AddScoped<IRolData, RolData>();
            services.AddScoped<IBaseModelBusiness<RolCreatedDto, RolEditDto, RolListDto>,RolBusiness>();



            services.AddScoped<IUserData, UserData>();
            services.AddScoped<IBaseModelData<User>, UserData>();

            services.AddScoped<IUserData, UserData>();
            services.AddScoped<IBaseModelBusiness<UserCreatedDto, UserEditDto, UserListDto>, UserBusiness>();


            return services;
        }
    }
}
