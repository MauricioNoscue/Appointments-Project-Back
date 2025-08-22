using Business_Back;
using Business_Back.Implements.ModelBusinessImplements.Infrastructure;
using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Infrastructure;
using Business_Back.Services;
using Data_Back;
using Data_Back.Implements;
using Data_Back.Implements.ModelDataImplement.Infrastructure;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface;
using Data_Back.Interface.IBaseModelData;
using Data_Back.Interface.IDataModels.Infrastructure;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back;
using Entity_Back.Dto.InfrastructureDto.CityDto;
using Entity_Back.Dto.InfrastructureDto.Departament;
using Entity_Back.Dto.InfrastructureDto.DepartamentDto;
using Entity_Back.Dto.InfrastructureDto.InstitutionDto;
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
    public static class ServiceExtensionsBussinesData
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {



            services.AddScoped<IBaseModelData<Rol>, RolData>();
            services.AddScoped<IRolData, RolData>();
            services.AddScoped<IBaseModelBusiness<RolCreatedDto, RolEditDto, RolListDto>, RolBusiness>();

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

            // Citation
            services.AddScoped<IBaseModelData<Citation>, CitationsData>();
            services.AddScoped<ICitationsData, CitationsData>();
            services.AddScoped<IBaseModelBusiness<CitationCreateDto, CitationEditDto, CitationListDto>, CitationBusiness>();

            // ConsultingRoom
            services.AddScoped<IBaseModelData<ConsultingRoom>, ConsultingRoomData>();
            services.AddScoped<IConsultingRoomData, ConsultingRoomData>();
            services.AddScoped<IBaseModelBusiness<ConsultingRoomCreateDto, ConsultingRoomEditDto, ConsultingRoomListDto>, ConsultingRoomBusiness>();

            // Doctor
            services.AddScoped<IBaseModelData<Doctor>, DoctorData>();
            services.AddScoped<IDoctorData, DoctorData>();
            services.AddScoped<IBaseModelBusiness<DoctorCreateDto, DoctorEditDto, DoctorListDto>, DoctorBusiness>();

            // ScheduleHour
            services.AddScoped<IBaseModelData<ScheduleHour>, ScheduleHourData>();
            services.AddScoped<IScheduleHourData, ScheduleHourData>();
            services.AddScoped<IBaseModelBusiness<ScheduleHourCreateDto, ScheduleHourEditDto, ScheduleHourListDto>, ScheduleHourBusiness>();

            // Shedule
            services.AddScoped<IBaseModelData<Shedule>, SheduleData>();
            services.AddScoped<ISheduleData, SheduleData>();
            services.AddScoped<IBaseModelBusiness<SheduleCreateDto, SheduleEditDto, SheduleListDto>, SheduleBusiness>();

            //TypeCitation
            services.AddScoped<IBaseModelData<TypeCitation>, TypeCitationData>();
            services.AddScoped<ITypeCitationData, TypeCitationData>();
            services.AddScoped<IBaseModelBusiness<TypeCitationCreateDto, TypeCitationEditDto, TypeCitationListDto>, TypeCitationBusiness>();

            //institution
            services.AddScoped<IBaseModelData<Institution>, InstitutionData>();
            services.AddScoped<IInstitutionData, InstitutionData>();
            services.AddScoped<IBaseModelBusiness<InstitutionCreatedDto, InstitutionEditDto, InstitutionListDto>, InstitutionBusiness>();

            // City
            services.AddScoped<IBaseModelData<City>, CityData>();
            services.AddScoped<ICityData, CityData>();
            services.AddScoped<IBaseModelBusiness<CityCreatedDto, CityEditDto, CityListDto>, CityBusiness>();

            // Department
            services.AddScoped<IBaseModelData<Departament>, DepartamentData>();
            services.AddScoped<IDepartamentData, DepartamentData>();
            services.AddScoped<IBaseModelBusiness<DepartamentCreatedDto, DepartamentEditDto, DepartamentListDto>, DepartamentBusiness>();

            services.AddScoped<JWTService>();

            services.AddScoped<AuthService>();



            return services;
        }
    }
}
