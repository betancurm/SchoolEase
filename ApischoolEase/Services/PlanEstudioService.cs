using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class PlanEstudioService : IPlanEstudioService
    {
        SchoolEaseContext context;
        public PlanEstudioService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<PlanEstudio> Get()
        {
            return context.PlanesEstudios;
        }
        public async Task Save(PlanEstudio planEstudio)
        {
            context.PlanesEstudios.Add(planEstudio);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, PlanEstudio planEstudio)
        {
            var PlanEstudioActual = context.PlanesEstudios.Find(id);
            if (PlanEstudioActual != null)
            {
                PlanEstudioActual.Descripcion = planEstudio.Descripcion;
                PlanEstudioActual.Porcentaje = planEstudio.Porcentaje;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var PlanEstudioActual = context.PlanesEstudios.Find(id);
            if (PlanEstudioActual != null)
            {
                context.PlanesEstudios.Remove(PlanEstudioActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IPlanEstudioService
    {
        IEnumerable<PlanEstudio> Get();
        Task Save(PlanEstudio planEstudio);
        Task Update(int id, PlanEstudio planEstudio);
        Task Delete(int id);
    }
}
