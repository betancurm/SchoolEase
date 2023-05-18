using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Asignacion
    {
        public int IdAsignacion { get; set; }
        //Relacion con la tabla Grupo
        public int IdGrupo { get; set; }
        [JsonIgnore]
        public virtual Grupo? Grupo { get; set; }
        //Relacion con la tabla Asignatura
        public int IdAsignatura { get; set; }
        [JsonIgnore]
        public virtual Asignatura? Asignatura { get; set; }
        //Relacion con la tabla Docente
        public int IdDocente { get; set; }
        [JsonIgnore]
        public virtual Docente? Docente { get; set; }
        //Relacion con la tabla Horario
        public int IdHorario { get; set; }
        [JsonIgnore]
        public virtual Horario? Horario { get; set; }

        public int IdEstudiante { get; set; }
        [JsonIgnore]
        public virtual Estudiante? Estudiante { get; set; }
       
        [JsonIgnore]
        public ICollection<Calificacion>? Calificaciones { get; set; }


    }
}
