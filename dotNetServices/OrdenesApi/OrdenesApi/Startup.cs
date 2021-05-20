using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrdenesCore.Interfaces;
using OrdenesInfraestructure.Repositories;
using OrdenesCore.Entities;
using OrdenesInfraestructure.Data;
using Microsoft.EntityFrameworkCore;
using OrdenesCore.Services;
using OrdenesInfraestructure.Profiles;
using OrdenesInfraestructure.WebServices;
using OrdenesInfraestructure.Emails;

namespace OrdenesApi
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            services.AddControllers();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbOrdenes")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAsyncRepository<Ordenes>, OrdenesRepository>();
            services.AddScoped<IAsyncRepository<DetalleOrdenes>, DetalleOrdenesRepository>();
            services.AddScoped<IRestClientCarritoCompras, RestClientCarritoCompras>();
            services.AddScoped<IRestClientBroker, RestClientBroker>();
            services.AddScoped<ISendEmails, SendEmails>();
            services.AddScoped<IOrdenService, OrdenService>();
            services.AddAutoMapper(typeof(OrdenesProfile), typeof(DetalleOrdenesProfile));
            services.AddHttpClient("disponibilidad", client =>
                {
                    client.BaseAddress = new Uri(Configuration["BaseUrl"]);
                });
            services.AddHttpClient("limpiarCarrito", client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
            services.AddHttpClient("colocarOrdenBroker", client =>
            {
                client.BaseAddress = new Uri(Configuration["BaseUrl"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
