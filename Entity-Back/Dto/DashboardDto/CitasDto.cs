namespace Entity_Back.Dto.DashboardDto
{
    public class CitasDto
    {
        public int TotalCitasDia { get; set; }
        public int TotalCitasSemana { get; set; }
        public int TotalCitasMes { get; set; }
        public Dictionary<string, int> DistribucionPorEspecialidad { get; set; }
        public Dictionary<string, int> EstadosCitas { get; set; }
    }
}