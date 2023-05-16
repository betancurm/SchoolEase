using System.Text.Json.Serialization;

namespace ApischoolEase.Models
{
    public class PlanEstudio
    {
        public int IdPlanEstudio { get; set; }
        public string Descripcion { get; set; }
        public decimal Porcentaje { get; set; }
        [JsonIgnore]
        public virtual ICollection<Calificacion>? Calificaciones { get; set; }
    }
}
