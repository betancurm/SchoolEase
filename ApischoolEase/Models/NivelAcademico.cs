using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class NivelAcademico
    {
        public int IdNivelAcademico { get; set; }
        public int IdPeriodoAcademico { get; set; }
        public tiponivelacademico TipoNivelAcademico { get; set; }
        [JsonIgnore]
        public virtual PeriodoAcademico? PeriodoAcademico { get; set; }
        [JsonIgnore]
        public virtual ICollection<JornadaAcademica>? JornadasAcademicas { get; set; }
        [JsonIgnore]
        public virtual ICollection<GradoAcademico>? GradosAcademicos { get; set; }
    }
    public enum tiponivelacademico
    {
        Preescolar, Primaria, Secundaria, Media, Superior, Postgrado, Maestria, Doctorado
    }
}
