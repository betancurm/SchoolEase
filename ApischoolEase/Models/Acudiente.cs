using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Acudiente : Persona
    {
        public EstadoCivil EstadoCivil { get; set; }
        public RelacionEstudiante RelacionEstudiante { get; set; }
        [JsonIgnore]
        public virtual ICollection<Matricula>? Matriculas { get; set; }
    }
    public enum EstadoCivil
    {
        Soltero,
        UnionLibre,
        Casado,
        Divorciado,
        Viudo
    }
    public enum RelacionEstudiante
    {
        Padre,
        Madre,
        Abuelo,
        Abuela,
        Tio,
        Tia,
        Hermano,
        Hermana,
        Primo,
        Prima,
        Otro
    }
}
