using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class JornadaAcademicaService : IJornadaAcademicaService
    {
        SchoolEaseContext context;
        public JornadaAcademicaService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<JornadaAcademica> Get()
        {   
            return context.JornadasAcademicas;          
        }
        public async Task Save(JornadaAcademica jornadaAcademica)
        {
            context.JornadasAcademicas.Add(jornadaAcademica);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id , JornadaAcademica jornadaAcademica)
        {
            var JornadaActual = context.JornadasAcademicas.Find(id);
            if (JornadaActual != null)
            {
                 JornadaActual.TipoJornadaAcademica = jornadaAcademica.TipoJornadaAcademica;
                JornadaActual.HoraInicio = jornadaAcademica.HoraInicio;
                JornadaActual.HoraFin = jornadaAcademica.HoraFin;
                JornadaActual.IdNivelAcademico = jornadaAcademica.IdNivelAcademico;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var JornadaActual = context.JornadasAcademicas.Find(id);
            if (JornadaActual != null)
            {
                context.JornadasAcademicas.Remove(JornadaActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IJornadaAcademicaService
    {
        IEnumerable<JornadaAcademica> Get();
        Task Save(JornadaAcademica jornadaAcademica);
        Task Update(int id , JornadaAcademica jornadaAcademica);
        Task Delete(int id);
    }
}
