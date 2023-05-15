using System.Net.Http.Json;
using System.Text.Json;
using WebAppSchoolEase.Models;

namespace WebAppSchoolEase.Services
{
    public class DocenteService:IDocenteService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
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
    }



    public interface IDocenteService
    {
        Task<List<Docente>?> Get();
        Task Add(Docente docente);

    }
}

