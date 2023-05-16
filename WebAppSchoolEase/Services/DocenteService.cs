using System.Net.Http.Json;
using System.Text.Json;
using WebAppSchoolEase.Models;

namespace WebAppSchoolEase.Services
{
    public class DocenteService:IDocenteService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
        public DocenteService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Docente>?> Get()
        {
            var response = await client.GetAsync("api/docente");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Docente>>(content, options);

        }
        public async Task Add(Docente docente)
        {
            var response = await client.PostAsync("api/docente", JsonContent.Create(docente));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Delete(int id)
        {
            var response = await client.DeleteAsync($"api/docente/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Update(Docente docente)
        {
            var response = await client.PutAsync($"api/docente/{docente.Id}", JsonContent.Create(docente));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
    }



    public interface IDocenteService
    {
        Task<List<Docente>?> Get();
        Task Add(Docente docente);
        Task Delete(int id);
        Task Update(Docente docente);
    }
}

