using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAppSchoolEase;
using WebAppSchoolEase.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var apiSchoolEase = builder.Configuration.GetValue<string>("apiSchoolEase");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiSchoolEase) });
builder.Services.AddScoped<IPeriodoAcademicoService, PeriodoAcademicoService>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IAcudienteService, AcudienteService>();
builder.Services.AddScoped<IDocenteService, DocenteService>();

builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<IAsignaturaService, AsignaturaService>();
builder.Services.AddScoped<IGrupoService, GrupoService>();
builder.Services.AddScoped<ICalificacionService, CalificacionService>();
builder.Services.AddScoped<IJornadaAcademicaService, JornadaAcademicaService>();
builder.Services.AddScoped<INivelAcademicoService, NivelAcademicoService>();
builder.Services.AddScoped<IGradoAcademicoService, GradoAcademicoService>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();


await builder.Build().RunAsync();
