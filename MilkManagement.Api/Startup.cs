using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MilkManagement.Domain;
using MilkManagement.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace MilkManagement.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IHostingEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddDbContext<MilkManagementDbContext>(options =>
            {
                options.UseNpgsql(_hostingEnvironment.IsDevelopment()
                    ? Configuration.GetConnectionString("Development")
                    : Configuration.GetConnectionString("Production"));
                options.EnableSensitiveDataLogging();

                options.ConfigureWarnings(builder => builder.Throw());
            });
            DataAccessRegistry.RegisterRepository(services);
            ComponentAccessRegistry.RegisterServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Milk Management Api",
                    Description = "To Care of Financial situations of Milk Business",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Uzair Iqbal", Email = "Uzair.qq@outlook.com" },
                    License = new License { Name = "Under The Terms And Agreements Of IQBAL DAIRY FARM" }
                });
            });
            services.AddAutoMapper();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory
                .AddConsole()
                .AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
