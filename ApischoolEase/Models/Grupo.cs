using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Grupo
    {
        public int IdGrupo { get; set; }
        public int Vacantes { get; set; }
        [JsonIgnore]
        public int VacantesDisponibles { get; set; }
        [JsonIgnore]
        public int VacantesOcupadas { get; set; }
        public GradoSeccion NombreGrupo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Asignacion>? Asignaciones { get; set; }
        [JsonIgnore]
        public virtual ICollection<Matricula>? Matriculas { get; set; }
    }
    public enum GradoSeccion
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N
    }
}
