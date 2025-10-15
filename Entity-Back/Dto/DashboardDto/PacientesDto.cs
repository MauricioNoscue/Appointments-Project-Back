namespace Entity_Back.Dto.DashboardDto
{
    public class PacientesDto
    {
        public List<NuevosPacientesDto> NuevosRegistrados { get; set; }
        public int PacientesActivos { get; set; }
        public int PacientesInactivos { get; set; }
    }

    public class NuevosPacientesDto
    {
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
    }
}