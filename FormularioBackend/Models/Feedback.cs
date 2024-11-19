using FormularioBackend.Enums;

namespace FormularioBackend.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public TipoEnum? Tipo { get; set; }
        public StatusEnum Status { get; set; }
    }
}
