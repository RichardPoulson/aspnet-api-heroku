using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models; // For Swashbuckle and Swagger
using Microsoft.EntityFrameworkCore;
using aspnet_api_heroku.Models;


namespace aspnet_api_heroku
{
    /// <summary>
    /// Used by the web host for configuration.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// After creating a <see cref="Startup"/> class, set the configuration.
        /// </summary>
        /// <param name="configuration">
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration?view=dotnet-plat-ext-3.1">IConfiguration Interface (Microsoft.Extensions.Configuration) | Microsoft Docs</see>
        /// </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// <list type="number">
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration?view=dotnet-plat-ext-3.1">IConfiguration Interface (Microsoft.Extensions.Configuration) | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/get">get - C# Reference | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>This method gets called by the runtime. Use this method to add services to the container.
        /// <list type="number">
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.mvcservicecollectionextensions.addcontrollers?view=aspnetcore-3.1">MvcServiceCollectionExtensions.AddControllers Method (Microsoft.Extensions.DependencyInjection) | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1">Dependency injection in ASP.NET Core | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="services">
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection?view=dotnet-plat-ext-3.1">IServiceCollection Interface (Microsoft.Extensions.DependencyInjection) | Microsoft Docs</see>
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds the database context to the DI container and
            // specify that the database context will use an in-memory database.
            services.AddDbContext<TodoContext>(opt =>
               opt.UseInMemoryDatabase("TodoList"));
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// Defines a class that provides the mechanisms to configure an application's request pipeline.<br/>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder?view=aspnetcore-3.1">IApplicationBuilder Interface (Microsoft.AspNetCore.Builder) | Microsoft Docs</see>
        /// </param>
        /// <param name="env">
        /// Provides information about the web hosting environment an application is running in.<br/>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.iwebhostenvironment?view=aspnetcore-3.1">IWebHostEnvironment Interface (Microsoft.AspNetCore.Hosting) | Microsoft Docs</see>
        /// </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(); // Enable middleware to serve generated Swagger as a JSON endpoint.

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
