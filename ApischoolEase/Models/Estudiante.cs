using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Estudiante :Persona
    {
        [JsonIgnore]
        public virtual ICollection<Calificacion>? Calificaciones { get; set; }
        [JsonIgnore]
        public virtual ICollection<Matricula>? Matriculas { get; set; }

    }
}
