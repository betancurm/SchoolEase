using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class AsignaturaService : IAsignaturaService
    {
        SchoolEaseContext context;
        public AsignaturaService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Asignatura> Get()
        {
            return context.Asignaturas;
        }
        public async Task Save(Asignatura asignatura)
        {
            context.Asignaturas.Add(asignatura);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Asignatura asignatura)
        {
            var AsignaturaActual = context.Asignaturas.Find(id);
            if (AsignaturaActual != null)
            {
                AsignaturaActual.NombreAsignatura = asignatura.NombreAsignatura;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var AsignaturaActual = context.Asignaturas.Find(id);
            if (AsignaturaActual != null)
            {
                context.Asignaturas.Remove(AsignaturaActual);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface IAsignaturaService
    {
        IEnumerable<Asignatura> Get();
        Task Save(Asignatura asignatura);
        Task Update(int id, Asignatura asignatura);
        Task Delete(int id);
    }
}
