using ApischoolEase.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<>;

var app = builder.Build();

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
