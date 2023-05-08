namespace ApischoolEase.Models
{
    public class GradoAcademico
    {
        public int IdGradoAcademico { get; set; }
        public string Descripcion { get; set; }
        public int IdNivelAcademico { get; set; }
        public NivelAcademico? NivelAcademico { get; set; }
    }
}
