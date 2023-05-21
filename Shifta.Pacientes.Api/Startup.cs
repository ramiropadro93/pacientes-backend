using Microsoft.Extensions.Configuration;
using Shifta.Pacientes.Business.Services;
using Shifta.Pacientes.DataAccess;
using Shifta.Pacientes.DataAccess.Interfaces;
using Shifta.Pacientes.DataAccess.Repositories;

namespace Shifta.Pacientes.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers
            services.AddControllers();

            // Add services and repositories
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddScoped<MongoDBContext>();
            services.AddCors();

            // Add any other dependencies or services needed

            // Configure Swagger (if required)
            services.AddSwaggerGen();

            string connectionString = Configuration.GetConnectionString("MongoDBConnection");
            services.AddSingleton(connectionString);
            // Configure other services
            // ...

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable Swagger (if required)
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            // Configure routing and endpoints
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
