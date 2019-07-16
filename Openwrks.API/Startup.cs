using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Events;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;
using Openwrks.API.Middleware;
using Microsoft.AspNetCore.Routing;
using Openwrks.Data.Db;
using Openwrks.Business;
using System.IO;

namespace Openwrks.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogger>(c =>
            {
                var env = c.GetService<IHostingEnvironment>();
                var log = new LoggerConfiguration();
                log.WriteTo.MSSqlServer(Configuration.GetConnectionString("Serilog"), "Api",
                    autoCreateSqlTable: true, restrictedToMinimumLevel: LogEventLevel.Warning);
                

                return log.CreateLogger();
            });

            #region MVC
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #endregion MVC
            
            #region AutoMapper
            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile(new ViewModels.MappingProfile());
            });
            #endregion AutoMapper


            #region Extension Methods
            services.AddDataLayer(Configuration.GetConnectionString("OpenwrksApiDb"));
            services.AddBusinessLayer();
            #endregion Extension Methods


            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Openwrks", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("basic", new BasicAuthScheme { Type = "basic" });

            });


            #endregion Swagger
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseMiddleware<ExceptionHandler>();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler();
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
                builder.Build();
            });

            app.UseHttpsRedirection();
            app.UseMvc(ConfigureRoutes);

            // Configure Swagger for API documentation
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Openwrks API v1");
            });


        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // Routes are defined at the controller/action level using RouteAttribute.
        }

        private string GetXmlCommentsPath()
        {
            var name = Assembly.GetAssembly(typeof(Startup)).GetName().Name;
            var app = PlatformServices.Default.Application;
            return System.IO.Path.Combine(app.ApplicationBasePath, $"{name}.xml");
        }

        private string GetXmlCommentsPathForViewModels()
        {
            var name = Assembly.GetAssembly(typeof(Startup)).GetName().Name;
            var app = PlatformServices.Default.Application;
            return System.IO.Path.Combine(app.ApplicationBasePath, $"{name}.ViewModels.xml");
        }
    }
}
