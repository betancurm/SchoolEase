using System.Net.Http.Json;
using System.Text.Json;
using WebAppSchoolEase.Models;

namespace WebAppSchoolEase.Services
{
    public class NivelAcademicoService : INivelAcademicoService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;

        public NivelAcademicoService(HttpClient httpClient)
        {

            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<NivelAcademico>?> Get()
        {
            var response = await client.GetAsync("api/NivelAcademico");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<NivelAcademico>>(content, options);

        }
        public async Task Add(NivelAcademico nivelAcademico)
        {
            var response = await client.PostAsync("api/NivelAcademico", JsonContent.Create(nivelAcademico));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Delete(int id)
        {
            var response = await client.DeleteAsync($"api/NivelAcademico/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task Update(NivelAcademico nivelAcademico)
        {
            var response = await client.PutAsync($"api/NivelAcademico/{nivelAcademico.IdNivelAcademico}", JsonContent.Create(nivelAcademico));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
    }

    public interface INivelAcademicoService
    {
        Task<List<NivelAcademico>?> Get();
        Task Add(NivelAcademico nivelAcademico);
        Task Delete(int id);
        Task Update(NivelAcademico nivelAcademico);
    }
}
