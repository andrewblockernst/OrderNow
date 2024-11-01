using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Net.Http;
using System.Net.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Agregamos el contexto de base de datos
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SDBOrderNow")));

// Agregamos el servicio de orden
builder.Services.AddScoped<OrderService>();

// Configuración de HttpClient
builder.Services.AddHttpClient<OrderService>();

// Configuración de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderNow", Version = "v1" });
});

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllFrontend",
        policy => policy.WithOrigins("http://127.0.0.1:5500/frontend/index.html") 
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Middleware de desarrollo y Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de HTTPS
app.UseHttpsRedirection();

// Habilitar CORS con la política definida
app.UseCors("AllowAllFrontend");

app.MapControllers(); // Mapear los controladores
app.Run();
