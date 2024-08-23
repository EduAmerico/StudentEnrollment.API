using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.API.Data;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
{
    // Configuração do DbContext com MySQL
    services.AddDbContext<StudentContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))));

    // Outros serviços
    services.AddControllers();

    // Configuração do Swagger
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Enrollment API", Version = "v1" });
    });
}
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Enrollment API v1");
        });

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
