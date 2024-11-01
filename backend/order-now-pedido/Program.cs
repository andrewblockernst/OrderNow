using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar contexto de base de datos
builder.Services.AddDbContext<OrderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SDBOrderNow")));

// Agregar el servicio de orden
builder.Services.AddScoped<OrderService>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Permitir cualquier origen
               .AllowAnyMethod() // Permitir cualquier método (GET, POST, etc.)
               .AllowAnyHeader(); // Permitir cualquier encabezado
    });
});

// Configuración de HttpClient
builder.Services.AddHttpClient<OrderService>();

// Configuración de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderNow", Version = "v1" });
});

var app = builder.Build();

// Middleware de desarrollo y Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de CORS
app.UseCors("AllowAllOrigins"); // Aplicar la política de CORS

// Middleware de HTTPS
app.UseHttpsRedirection();

app.MapControllers(); // Mapear los controladores
app.Run();
