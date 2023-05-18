using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int Nota { get; set; }
        public float Porcentaje { get; set; }

        //Relacion con la tabla Asignacion
        public int IdAsignacion { get; set; }
        [JsonIgnore]
        public virtual Asignacion? Asignacion { get; set; }
    }
}
