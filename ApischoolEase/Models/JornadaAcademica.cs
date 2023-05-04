namespace ApischoolEase.Models
{
    public class JornadaAcademica
    {
        public int IdJornadaAcademica { get; set; }
        public tipoJornadaAcademica TipoJornadaAcademica { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
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
