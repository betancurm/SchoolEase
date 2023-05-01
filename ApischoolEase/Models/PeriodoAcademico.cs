namespace ApischoolEase.Models
{
    public class PeriodoAcademico
    {
        public int IdPeriodoAcademico { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        
        public TipoPeriodo TipoPeriodo { get; set; }

    }
    public enum TipoPeriodo
    {
        CalendarioA, CalendarioB
    }
}
