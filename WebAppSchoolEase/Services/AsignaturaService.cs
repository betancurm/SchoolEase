using WebAppSchoolEase.Models;
using System.Net.Http.Json;
using System.Text.Json;
namespace WebAppSchoolEase.Services
{
    public class AsignaturaService : IAsignaturaService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
        public AsignaturaService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Asignatura>?> Get()
        {
            var response = await client.GetAsync("api/Asignatura");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Asignatura>>(content, options);

        }
        public async Task Add(Asignatura asignatura)
        {
            var response = await client.PostAsync("api/Asignatura", JsonContent.Create(asignatura));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Delete(int id)
        {
            var response = await client.DeleteAsync($"api/Asignatura/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Update(Asignatura asignatura)
        {
            var response = await client.PutAsync($"api/Asignatura/{asignatura.idAsignatura}", JsonContent.Create(asignatura));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

    }
    public interface IAsignaturaService
    {
        Task<List<Asignatura>?> Get();
        Task Add(Asignatura asignatura);
    }
}

