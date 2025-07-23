using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Services;
using Data_Back.Implements.ModelDataImplement.Infrastructure;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IBaseModelData;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Dto.SecurityDto.FormDto;
using Entity_Back.Dto.SecurityDto.FormModuleDto;
using Entity_Back.Dto.SecurityDto.ModuleDto;
using Entity_Back.Dto.SecurityDto.PermissionDto;
using Entity_Back.Dto.SecurityDto.RolDto;
using Entity_Back.Dto.SecurityDto.RolFormPermissionDto;
using Entity_Back.Dto.SecurityDto.RolUserDto;
using Entity_Back.Dto.SecurityDto.UserDto;
using Entity_Back.Models.Infrastructure;
using Entity_Back.Models.Security;
using Entity_Back.Models.SecurityModels;

namespace Web_back.Extension
{
    public static  class ServiceExtensionsBussinesData
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {


           
            services.AddScoped<IBaseModelData<Rol>, RolData>();
            services.AddScoped<IRolData, RolData>();
            services.AddScoped<IBaseModelBusiness<RolCreatedDto, RolEditDto, RolListDto>,RolBusiness>();

            services.AddScoped<IBaseModelData<User>, UserData>();
            services.AddScoped<IUserData, UserData>();
            services.AddScoped<IBaseModelBusiness<UserCreatedDto, UserEditDto, UserListDto>, UserBusiness>();


            services.AddScoped<IBaseModelData<RolUser>, RolUserData>();
            services.AddScoped<IRolUserData, RolUserData>();
            services.AddScoped<IBaseModelBusiness<RolUserCreatedDto, RolUserEditDto, RolUserList>, RolUserBusiness>();

            // Permission
            services.AddScoped<IBaseModelData<Permission>, PermissionData>();
            services.AddScoped<IPermissionData, PermissionData>();
            services.AddScoped<IBaseModelBusiness<PermissionCreatedDto, PermissionEditDto, PermissionListDto>, PermissionBusiness>();

            // Module
            services.AddScoped<IBaseModelData<Module>, ModuleData>();
            services.AddScoped<IModuleData, ModuleData>();
            services.AddScoped<IBaseModelBusiness<ModuleCreatedDto, ModuleEditDto, ModuleListDto>, ModuleBusiness>();

            // Form
            services.AddScoped<IBaseModelData<Form>, FormData>();
            services.AddScoped<IFormData, FormData>();
            services.AddScoped<IBaseModelBusiness<FormCreatedDto, FormEditDto, FormListDto>, FormBusiness>();

            // FormModule
            services.AddScoped<IBaseModelData<FormModule>, FormModuleData>();
            services.AddScoped<IFormModuleData, FormModuleData>();
            services.AddScoped<IBaseModelBusiness<FormModuleCreatedDto, FormModuleEditDto, FormModuleListDto>, FormModuleBusiness>();

            // RolFormPermission
            services.AddScoped<IBaseModelData<RolFormPermission>, RolFormPermissionData>();
            services.AddScoped<IRolFormPermissionData, RolFormPermissionData>();
            services.AddScoped<IBaseModelBusiness<RolFormPermissionCreatedDto, RolFormPermissionEditDto, RolFormPermissionListDto>, RolFormPermissionBusiness>();

            //Infrastructure
            services.AddScoped<IBaseModelData<Branch>, BranchData>();
            services.AddScoped<IBaseModelData<Institution>, InstitutionData>();
            services.AddScoped<IBaseModelData<City>, CityData>();
            services.AddScoped<IBaseModelData<Departament>, DepartamentData>();



            services.AddScoped<JWTService>();

            services.AddScoped<AuthService>();



            return services;
        }
    }
}
