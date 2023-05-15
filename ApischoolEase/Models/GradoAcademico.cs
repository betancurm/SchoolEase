using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class GradoAcademico
    {
        public int IdGradoAcademico { get; set; }
        public string Descripcion { get; set; }
        public int IdNivelAcademico { get; set; }
        [JsonIgnore]
        public NivelAcademico? NivelAcademico { get; set; }
        [JsonIgnore]
        public virtual ICollection<Matricula>? Matriculas { get; set; }
    }
}
