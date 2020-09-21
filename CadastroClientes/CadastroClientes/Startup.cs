using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Common.Handler;
using CadastroClientes.Common.Implementation;
using CadastroClientes.Common.Interface;
using CadastroClientes.Common.Model;
using CadastroClientes.Data.Context;
using CadastroClientes.Data.IoC;
using MediatR;
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

namespace CadastroClientes
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
            var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
            services.AddDbContext<CadastroClientesContext>(options => options.UseMySql(connection));
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
            services.AddMvc();
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddScoped<INotificationHandler<Notifications>, NotifiyHandler>();
            services.AddScoped<INotify, Notify>();
            services.AddScoped<CadastroClientesContext, CadastroClientesContext>();
            DependencyInjectorCadastroClientes.Registrar(services);
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "Prova CrMall",
                    Version = "V1",
                    Description = "CRUD de Cliente",
                    Contact = new OpenApiContact
                    {
                        Name = "Thiago Moço Vidal",
                        Email = "thiago.tmv@gmail.com"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Exercício Livraria");
            });
        }
    }
}
