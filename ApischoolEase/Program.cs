using ApischoolEase;
using ApischoolEase.Models;
using ApischoolEase.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7014")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolEaseContext>(p => p.UseInMemoryDatabase("SchooEaseDB"));
//Aca se registra el servicio para que se pueda inyectar en el controlador
builder.Services.AddScoped<IPeriodoAcademicoService, PeriodoAcademicoService>();



var app = builder.Build();
app.UseCors("MyCorsPolicy");

app.MapGet("/dbconexion", async ([FromServices] SchoolEaseContext DbContext) =>
{
    DbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria " + DbContext.Database.IsInMemory());
});

using (var scope = app.Services.CreateScope())
{
    var serv = scope.ServiceProvider;
    try
    {
        var contex = serv.GetRequiredService<SchoolEaseContext>();
        contex.Database.EnsureCreated();
    }
    catch (System.Exception)
    {
        var logger = serv.GetRequiredService<ILogger<Program>>();
        logger.LogError(System.Environment.NewLine + "Error al crear la base de datos");
    }

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors(); para adminsitrar las seguridad de la API
app.UseAuthorization();
//Welcome Page sirve para crear la pagina de inicio de la API
//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
