using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class GrupoService : IGrupoService
    {
        SchoolEaseContext context;
        public GrupoService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Grupo> Get()
        {
            return context.Grupos;
        }
        public async Task Save(Grupo grupo)
        {
            grupo.VacantesDisponibles = grupo.Vacantes;
            grupo.VacantesOcupadas = 0;
            context.Grupos.Add(grupo);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Grupo grupo)
        {
            var GrupoActual = context.Grupos.Find(id);
            if (GrupoActual != null)
            {
                GrupoActual.NombreGrupo = grupo.NombreGrupo;
                GrupoActual.Vacantes = grupo.Vacantes;
                GrupoActual.VacantesDisponibles = grupo.VacantesDisponibles;
                GrupoActual.VacantesOcupadas = grupo.VacantesOcupadas;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var GrupoActual = context.Grupos.Find(id);
            if (GrupoActual != null)
            {
                context.Grupos.Remove(GrupoActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IGrupoService
    {
        IEnumerable<Grupo> Get();
        Task Save(Grupo grupo);
        Task Update(int id, Grupo grupo);
        Task Delete(int id);
    }
}
