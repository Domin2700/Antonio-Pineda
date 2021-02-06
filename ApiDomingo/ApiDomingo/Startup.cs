using System.Configuration;
using ApiDomingo.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiDomingo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            // Este metodo me permite acceder al api desde el cliente
            services.AddCors(o => o.AddPolicy("MyCorsPolicy", builder =>
            {
                builder

                      .WithOrigins("http://localhost:4200")
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials();
            }));
    
            //Le asigno la cadena de conexion a mi contexto de datos
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SQLCnn")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            app.UseCors("MyCorsPolicy"); // Uso mis politicas Cors
            app.UseAuthentication();//Activo las autenticaciones
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
