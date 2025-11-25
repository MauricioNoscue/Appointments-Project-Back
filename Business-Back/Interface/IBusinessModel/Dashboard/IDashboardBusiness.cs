using Entity_Back.Dto.DashboardDto;

namespace Business_Back.Interface.IBusinessModel.Dashboard
{
    public interface IDashboardBusiness
    {
        Task<DashboardDto> GetDashboardDataAsync();

        Task<DoctorDashboardVmDto> GetDashboardAsync(int doctorId);
    }
}