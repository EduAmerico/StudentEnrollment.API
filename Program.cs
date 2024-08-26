using Microsoft.EntityFrameworkCore;
using StudentEnrollment.API.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; 


var builder = WebApplication.CreateBuilder(args);

// Configurar o DbContext para o banco de dados
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Adicionar suporte ao CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Adicionar serviços ao contêiner
builder.Services.AddControllers();  // Adiciona suporte para controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();  // Mapeia os controladores para as rotas

app.Run();
