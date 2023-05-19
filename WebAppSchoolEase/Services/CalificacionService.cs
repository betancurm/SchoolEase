using System.Net.Http.Json;
using System.Text.Json;
using WebAppSchoolEase.Models;

namespace WebAppSchoolEase.Services
{
    public class CalificacionService : ICalificacionService
    {

        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;

        public CalificacionService(HttpClient httpClient)
        {
            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Calificacion>?> Get()
        {
            var response = await client.GetAsync("api/calificacion");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Calificacion>>(content, options);
        }
        public async Task Add(Calificacion calificacion)
        {
            var response = await client.PostAsync("api/calificacion", JsonContent.Create(calificacion));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Update(Calificacion calificacion)
        {
            var response = await client.PutAsync($"api/calificacion/{calificacion.IdCalificacion}", JsonContent.Create(calificacion));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Delete(int id)
        {
            var response = await client.DeleteAsync($"api/calificacion/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

    }
    public interface ICalificacionService
    {
        Task<List<Calificacion>?> Get();
        Task Add(Calificacion calificacion);
    }
}
