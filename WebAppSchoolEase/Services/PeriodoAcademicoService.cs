using WebAppSchoolEase.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebAppSchoolEase.Services
{
    public class PeriodoAcademicoService : IPeriodoAcademicoService
    {
        private readonly HttpClient client;

        private readonly JsonSerializerOptions options;
        public PeriodoAcademicoService(HttpClient httpClient)
        {
            
            client = httpClient;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<List<PeriodoAcademico>?> Get()
        {
            var response = await client.GetAsync("api/periodoacademico");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<PeriodoAcademico>>(content, options);
            
        }
        public async Task Add(PeriodoAcademico periodoAcademico)
        {
            var response = await client.PostAsync("api/periodoacademico", JsonContent.Create(periodoAcademico));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
    }
    public interface IPeriodoAcademicoService
    {
        Task<List<PeriodoAcademico>?> Get();
        Task Add(PeriodoAcademico periodoAcademico);
    }
}
