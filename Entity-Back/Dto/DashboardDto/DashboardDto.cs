namespace Entity_Back.Dto.DashboardDto
{
    public class DashboardDto
    {
        public CitasDto Citas { get; set; }
        public PacientesDto Pacientes { get; set; }
        public DoctoresDto Doctores { get; set; }
        public KpisDto Kpis { get; set; }
    }
}