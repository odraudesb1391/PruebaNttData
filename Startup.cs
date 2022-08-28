using LuisCriolloPrueba.Modelos;
using LuisCriolloPrueba.Repositorio;
using LuisCriolloPrueba.Servicio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BaseDatosContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddControllers();
            AddSwagger(services);
            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            services.AddScoped<IServicioCliente, ServicioCliente>();
            services.AddScoped<IRepositorioPersona, RepositorioPersona>();
            services.AddScoped<IServicioPersona, ServicioPersona>();
            services.AddScoped<IRepositorioCuenta, RepositorioCuenta>();
            services.AddScoped<IServicioCuenta, ServicioCuenta>();
            services.AddScoped<IRepositorioMovimiento, RepositorioMovimiento>();
            services.AddScoped<IServicioMovimiento, ServicioMovimiento>();
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Prueba {groupName}",
                    Version = groupName,
                    Description = "Criollo Software",
                    Contact = new OpenApiContact
                    {
                        Name = "Criollo Software",
                        Email = string.Empty,
                        Url = new Uri("https://criollosoftware.com/"),
                    }
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BaseDatosContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            db.Database.Migrate();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaCriollo API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
