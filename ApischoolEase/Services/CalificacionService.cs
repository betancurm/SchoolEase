using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class CalificacionService : ICalificacionService
    {
        SchoolEaseContext context;
        public CalificacionService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Calificacion> Get()
        {
            return context.Calificaciones;
        }
        public async Task Save(Calificacion calificacion)
        {
            context.Calificaciones.Add(calificacion);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Calificacion calificacion)
        {
            var CalificacionActual = context.Calificaciones.Find(id);
            if (CalificacionActual != null)
            {
                CalificacionActual.Nota = calificacion.Nota;
                CalificacionActual.IdEstudiante = calificacion.IdEstudiante;
                CalificacionActual.IdPlanEstudio = calificacion.IdPlanEstudio;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var CalificacionActual = context.Calificaciones.Find(id);
            if (CalificacionActual != null)
            {
                context.Calificaciones.Remove(CalificacionActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface ICalificacionService
    {
        IEnumerable<Calificacion> Get();
        Task Save(Calificacion calificacion);
        Task Update(int id, Calificacion calificacion);
        Task Delete(int id);
    }
}
