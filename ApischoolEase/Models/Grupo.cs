namespace ApischoolEase.Models
{
    public class Grupo
    {
        public int IdGrupo { get; set; }
        public int Vacantes { get; set; }
        public int VacantesDisponibles { get; set; }
        public int VacantesOcupadas { get; set; }
        public GradoSeccion NombreGrupo { get; set; }
        public int IdGradoAcademico { get; set; }
        public GradoAcademico? GradoAcademico { get; set; }
    }
    public enum GradoSeccion
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N
    }
}
