using Business_Back;
using Business_Back.Implements.ModelBusinessImplements.Infrastructure;
using Business_Back.Implements.ModelBusinessImplements.Notification1;
using Business_Back.Implements.ModelBusinessImplements.Menu;
using Business_Back.Implements.ModelBusinessImplements.Security;
using Business_Back.Interface.BaseModelBusiness;
using Business_Back.Interface.IBusinessModel.Menu;
using Business_Back.Interface.IBusinessModel.Security;
using Business_Back.Services;
using Business_Back.Services.Citation;
using Data_Back;
using Data_Back.Implements;
using Data_Back.Implements.ModelDataImplement.Infrastructure;
using Data_Back.Implements.ModelDataImplement.Menu;
using Data_Back.Implements.ModelDataImplement.Notification1;
using Data_Back.Implements.ModelDataImplement.Refresh;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface;
using Data_Back.Interface.IBaseModelData;
using Data_Back.Interface.IDataModels.Infrastructure;
using Data_Back.Interface.IDataModels.Menu;
using Data_Back.Interface.IDataModels.Notifation;
using Data_Back.Interface.IDataModels.Security;
using Data_Back.Interface.Refresh;
using Entity_Back;
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
using Entity_Back.Models.Infrastructure;
using Entity_Back.Models.Notification;
using Entity_Back.Models.Security;
using Entity_Back.Models.SecurityModels;
using Business_Back.Implements.ModelBusinessImplements.Hospital;
using Business_Back.Interface.IBusinessModel.Hospital;
using Data_Back.Implements.ModelDataImplement.Hospital;
using Data_Back.Interface.IDataModels.Hospital;
using Entity_Back.Dto.HospitalDto.RelatedPerson;
using Entity_Back.Models.HospitalModel;
using Microsoft.AspNetCore.SignalR;
using Business_Back.Interface.IBusinessModel.Notification;

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
            services.AddScoped<IUserBusiness, UserBusiness>();


            services.AddScoped<IBaseModelData<RolUser>, RolUserData>();
            services.AddScoped<IRolUserData, RolUserData>();
            services.AddScoped<IBaseModelBusiness<RolUserCreatedDto, RolUserEditDto, RolUserList>, RolUserBusiness>();
            services.AddScoped<IRolUserBusiness, RolUserBusiness>();
            services.AddScoped<IRolFormPermissionBusiness
                    , RolFormPermissionBusiness
                    >();

            services.AddScoped<IRefreshTokenData, RefreshTokenData>();

            services.AddScoped<IPersonBusiness, PersonBusiness>();

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

            // Eps
            services.AddScoped<IBaseModelData<Eps>, EpsData>();
            services.AddScoped<IEpsData, EpsData>();
            services.AddScoped<IBaseModelBusiness<EpsCreatedDto, EpsEditDto, EpsListDto>, EpsBusiness>();

            // DocumentType
            services.AddScoped<IBaseModelData<DocumentType>, DocumentTypeData>();
            services.AddScoped<IDocumentTypeData, DocumentTypeData>();
            services.AddScoped<IBaseModelBusiness<DocumentTypeCreatedDto, DocumentTypeEditDto, DocumentTypeListDto>, DocumentTypeBusiness>();

            // Specialty
            services.AddScoped<IBaseModelData<Specialty>, SpecialtyData>();
            services.AddScoped<ISpecialtyData, SpecialtyData>();
            services.AddScoped<IBaseModelBusiness<SpecialtyCreatedDto, SpecialtyEditDto, SpecialtyListDto>, SpecialtyBusiness>();

            //Institution
            services.AddScoped<IBaseModelData<Institution>, InstitutionData>();
            services.AddScoped<IInstitutionData, InstitutionData>();
            services.AddScoped<IBaseModelBusiness<InstitutionCreatedDto, InstitutionEditDto, InstitutionListDto>, InstitutionBusiness>();


            //Branch
            services.AddScoped<IBaseModelData<Branch>, BranchData>();
            services.AddScoped<IBranchData, BranchData>();
            services.AddScoped<IBaseModelBusiness<BranchCreatedDto, BranchEditDto, BranchListDto>, BranchBusiness>();

            //City
            services.AddScoped<IBaseModelData<City>, CityData>();
            services.AddScoped<ICityData, CityData>();
            services.AddScoped<IBaseModelBusiness<CityCreatedDto, CityEditDto, CityListDto>, CityBusiness>();

            //Departament
            services.AddScoped<IBaseModelData<Departament>, DepartamentData>();
            services.AddScoped<IDepartamentData, DepartamentData>();
            services.AddScoped<IBaseModelBusiness<DepartamentCreatedDto, DepartamentEditDto, DepartamentListDto>, DepartamentBusiness>();

            services.AddScoped<IBaseModelData<Person>, PersonData>();
            services.AddScoped<IpersonData, PersonData>(); 
            services.AddScoped<IBaseModelBusiness<PersonCreatedDto, PersonEditDto, PersonListDto>, PersonBusiness>();

            services.AddScoped<ISheduleBusiness, SheduleBusiness>();
            services.AddScoped<IScheduleHourBusiness, ScheduleHourBusiness>();
            services.AddScoped<ICitationsBusiness, CitationBusiness>();



            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuBusiness, MenuBusiness>();

            //Doctor
            services.AddScoped<IDoctorBusiness, DoctorBusiness>();
            services.AddScoped<IDoctorData, DoctorData>();
            //Notificaciones
            services.AddScoped<IBaseModelData<Notification>, NotificationData>();
            services.AddScoped<INotificationData, NotificationData>();
            services.AddScoped<IBaseModelBusiness<NotificationCreateDto, NotificationEditDto, NotificationListDto>, NotificationBusiness>();


            // RelatedPerson: Data
            services.AddScoped<IBaseModelData<RelatedPerson>, RelatedPersonData>();
            services.AddScoped<IRelatedPersonData, RelatedPersonData>();

            // RelatedPerson: Business
            services.AddScoped<IRelatedPersonBusiness, RelatedPersonBussiness>();

            // IMPORTANTe: el controller pide el genérico, así que lo resolvemos con el específico
            services.AddScoped<IBaseModelBusiness<RelatedPersonCreatedDto, RelatedPersonEditDto, RelatedPersonListDto>>(sp =>
                sp.GetRequiredService<IRelatedPersonBusiness>());

            services.AddScoped<CitationCoreService>();
            services.AddSingleton<IUserIdProvider, SubUserIdProvider>();

            IServiceCollection serviceCollection = services.AddScoped<INotificationBusiness, NotificationBusiness>();



            services.AddScoped<JWTService>();

            services.AddScoped<AuthService>();

            // Dashboard
            services.AddScoped<Business_Back.Interface.IBusinessModel.Dashboard.IDashboardBusiness, Business_Back.Implements.ModelBusinessImplements.Dashboard.DashboardBusiness>();

            return services;
        }
    }
}
