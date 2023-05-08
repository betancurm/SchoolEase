namespace WebAppSchoolEase.Models
{
    public class PeriodoAcademico
    {
        public int IdPeriodoAcademico { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int TipoPeriodo { get; set; }
    } 

}
