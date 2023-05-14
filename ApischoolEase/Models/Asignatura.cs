using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Asignatura
    {
        public int IdAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
        [JsonIgnore]
        public virtual ICollection<Asignacion>? Asignaciones { get; set; }
    }
}
