using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Matricula
    {
        public int IdMatricula { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string InstitucionDeProcedencia { get; set; }
        public bool EsRepitente { get; set; }
        public bool NuevoOAntiguo { get; set; }

        //Realcion con Estudiante
        public int IdEstudiante { get; set; }
        [JsonIgnore]
        public Estudiante? Estudiante { get; set; }
        //Relacion con Grado Academico
        public int IdGradoAcademico { get; set; }
        [JsonIgnore]
        public GradoAcademico? GradoAcademico { get; set; }

        // Relacion con Acudiente
        public int IdAcudiente { get; set; }
        [JsonIgnore]
        public Acudiente? Acudiente { get; set; }

    }
}
