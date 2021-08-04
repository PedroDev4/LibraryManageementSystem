using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace LibraryManagement.Api.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "LSD Library Management System",
                    Description = "API básica com o propósito de demonstrar a utilização de um sistema de mensageria.",
                    Contact = new OpenApiContact
                    {
                        Name = "Team Dotnet Frwk",
                        Email = "teamdotnetfrwk@email.com",
                        Url = new Uri("https://rabelodeveloper.netlify.app/"),
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
                { c.SwaggerEndpoint("/swagger/v1/swagger.json", "LSD Library Management System"); });

            return app;
        }
    }
}