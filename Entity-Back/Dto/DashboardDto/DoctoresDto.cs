namespace Entity_Back.Dto.DashboardDto
{
    public class DoctoresDto
    {
        public List<TopDoctoresDto> TopDoctores { get; set; }
        public List<DoctoresDisponiblesDto> DoctoresDisponibles { get; set; }
        public Dictionary<string, int> RankingEspecialidades { get; set; }
    }

    public class TopDoctoresDto
    {
        public string NombreDoctor { get; set; }
        public int CitasAtendidas { get; set; }
    }

    public class DoctoresDisponiblesDto
    {
        public string NombreDoctor { get; set; }
        public int CuposLibres { get; set; }
    }
}