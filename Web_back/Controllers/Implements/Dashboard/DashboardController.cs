using Business_Back.Interface.IBusinessModel.Dashboard;
using Entity_Back.Dto.DashboardDto;
using Microsoft.AspNetCore.Mvc;

namespace Web_back.Controllers.Implements.Dashboard
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardBusiness _dashboardBusiness;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(IDashboardBusiness dashboardBusiness, ILogger<DashboardController> logger)
        {
            _dashboardBusiness = dashboardBusiness;
            _logger = logger;
        }

        [HttpGet("data")]
        public async Task<IActionResult> GetDashboardData()
        {
            try
            {
                var data = await _dashboardBusiness.GetDashboardDataAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener datos del dashboard");
                return StatusCode(500, "Error interno del servidor.");
            }
        }


        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetDoctorDashboard(int doctorId)
        {
            var result = await _dashboardBusiness.GetDashboardAsync(doctorId);
            return Ok(result);
        }

    }
}