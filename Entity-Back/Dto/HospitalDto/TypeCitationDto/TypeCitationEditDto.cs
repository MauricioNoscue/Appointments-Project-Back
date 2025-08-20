namespace Entity_Back
{
    public class TypeCitationEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}