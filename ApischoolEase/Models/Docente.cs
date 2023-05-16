using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Docente : Persona
    {
        public tiponivelacademico NivelAcademico { get; set; }
        public string Profesion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Asignacion> Asignaciones { get; set; }
    }
}
