using System.Net.Http.Json;
using System.Text.Json;
using WebAppSchoolEase.Models;

namespace WebAppSchoolEase.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;

        public MatriculaService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Matricula>?> Get()
        {
            var response = await client.GetAsync("api/matricula");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Matricula>>(content, options);

        }
        public async Task Add(Matricula matricula)
        {
            var response = await client.PostAsync("api/matricula", JsonContent.Create(matricula));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Delete(int id)
        {
            var response = await client.DeleteAsync($"api/matricula/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Update(Matricula matricula)
        {
            var response = await client.PutAsync($"api/matricula/{matricula.IdEstudiante}", JsonContent.Create(matricula));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

    }

    public interface IMatriculaService
    {
        Task<List<Matricula>?> Get();
        Task Add(Matricula matricula);
        Task Delete(int id);
        Task Update(Matricula matricula);
    }
}
