using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public DiaSemana DiaSemana{ get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        [JsonIgnore]
        public virtual ICollection<Asignacion>? Asignaciones { get; set; }
    }
    public enum DiaSemana
    {
        Lunes,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado,
        Domingo
    }
}
