using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregamos los controladores
builder.Services.AddControllers();

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "STOCK (ordernow)", Version = "v1" });
});

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SDBOrderNow")));

// Agregar el servicio de productos (Dependency Injection)
builder.Services.AddScoped<IProductService, ProductDbService>();

var app = builder.Build();

// Middleware de desarrollo y Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware de HTTPS
app.UseHttpsRedirection();
app.MapControllers(); // Mapear los controladores
app.Run();
