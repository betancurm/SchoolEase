using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int Nota { get; set; }

        //relacion con Estudiante
        public int IdEstudiante { get; set; }
        [JsonIgnore]
        public Estudiante? Estudiante { get; set; }
        //relacion con plan de estudio
        public int IdPlanEstudio { get; set; }
        [JsonIgnore]
        public PlanEstudio? PlanEstudio { get; set; }
 
    }
}
