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
            if (calificacion.Nota < 0 || calificacion.Nota > 5)
            {
                throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 5.");
            }

            if (calificacion.Porcentaje <0.05 || calificacion.Porcentaje > 0.20)
            {
                throw new ArgumentOutOfRangeException("El porcentaje debe estar entre 5% y 20%.");
            }

            context.Calificaciones.Add(calificacion);
            await context.SaveChangesAsync();
        }
        public async Task Update(int id, Calificacion calificacion)
        {
            if (calificacion.Nota < 0 || calificacion.Nota > 5)
            {
            }

            if (calificacion.Porcentaje <= 0.05 || calificacion.Porcentaje > 0.2)
            {
            }

            var CalificacionActual = context.Calificaciones.Find(id);
            if (CalificacionActual != null)
            {
                CalificacionActual.Porcentaje = calificacion.Porcentaje;
                CalificacionActual.Nota = calificacion.Nota;

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
