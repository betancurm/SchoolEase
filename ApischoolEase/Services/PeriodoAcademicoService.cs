using ApischoolEase.Models;

namespace ApischoolEase.Services
{
    public class PeriodoAcademicoService : IPeriodoAcademicoService
    {
        SchoolEaseContext context;
        public PeriodoAcademicoService(SchoolEaseContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<PeriodoAcademico> Get()
        {
            return context.PeriodosAcademicos;
        }
        public async Task Save(PeriodoAcademico periodoAcademico)
        {
            context.Add(periodoAcademico);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, PeriodoAcademico periodoAcademico)
        {
            var periodoAcademicoActual= context.PeriodosAcademicos.Find(id);
            if(periodoAcademicoActual != null)
            {
                periodoAcademicoActual.Nombre = periodoAcademico.Nombre;
                periodoAcademicoActual.FechaInicio = periodoAcademico.FechaInicio;
                periodoAcademicoActual.FechaFin = periodoAcademico.FechaFin;
                periodoAcademicoActual.TipoPeriodo = periodoAcademico.TipoPeriodo;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete (int id)
        {
            var periodoAcademicoActual = context.PeriodosAcademicos.Find(id);
            if (periodoAcademicoActual != null)
            {
                context.Remove(periodoAcademicoActual);
                await context.SaveChangesAsync();
            }
        }
    }
    public interface IPeriodoAcademicoService
    {
        IEnumerable<PeriodoAcademico> Get ();
        Task Save(PeriodoAcademico periodoAcademico);
        Task Update(int id, PeriodoAcademico periodoAcademico);
        Task Delete(int id);

    }
}
