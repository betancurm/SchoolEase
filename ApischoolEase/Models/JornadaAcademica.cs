namespace ApischoolEase.Models
{
    public class JornadaAcademica
    {
        public int IdJornadaAcademica { get; set; }
        public tipoJornadaAcademica TipoJornadaAcademica { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public int IdNivelAcademico { get; set; }
        public virtual NivelAcademico? NivelAcademico { get; set; }
    }
    public enum tipoJornadaAcademica
    {
        Mañana,
        Tarde,
        Noche
    }
}
