
namespace Hahn.ApplicatonProcess.May2020.Web.Swagger
{
    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Filters;

    public static class SwaggerService
    {

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hahn API",
                    Version = "v1",
                    Description = "Simple RESTful API built with ASP.NET Core 3.1 to show how to create RESTful services using a decoupled, maintainable architecture.",
                    Contact = new OpenApiContact
                    {
                        Name = "Sagheer ahmad",
                        Url = new Uri("https://www.linkedin.com/in/sagheerahmad/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                    },
                });
                cfg.ExampleFilters();
            });

            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicantionProcess");
                options.DocumentTitle = "HAHN API";
            });
            return app;
        }
    }
}
