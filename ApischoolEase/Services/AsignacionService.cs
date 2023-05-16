using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class AsignacionService : IAsignacionService
    {
        SchoolEaseContext context;
        public AsignacionService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Asignacion> Get()
        {
            return context.Asignaciones;
        }
        public async Task Save(Asignacion asignacion)
        {
            context.Asignaciones.Add(asignacion);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Asignacion asignacion)
        {
            var AsignacionActual = context.Asignaciones.Find(id);
            if (AsignacionActual != null)
            {
                AsignacionActual.IdAsignatura = asignacion.IdAsignatura;
                AsignacionActual.IdGrupo = asignacion.IdGrupo;
                AsignacionActual.IdDocente = asignacion.IdDocente;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var AsignacionActual = context.Asignaciones.Find(id);
            if (AsignacionActual != null)
            {
                context.Asignaciones.Remove(AsignacionActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IAsignacionService
    {
        IEnumerable<Asignacion> Get();
        Task Save(Asignacion asignacion);
        Task Update(int id, Asignacion asignacion);
        Task Delete(int id);
    }
}
