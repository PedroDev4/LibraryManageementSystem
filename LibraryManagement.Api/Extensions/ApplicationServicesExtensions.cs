
using System;
using AutoMapper;
using LibraryManagement.Application;
using LibraryManagement.Application.Mapping;
using LibraryManagement.Business.Interfaces;
using LibraryManagement.Infrastructure.Repository;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServicesExtensions(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICustomerServices, CustomerServices>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddMassTransit(bus =>
            {
                bus.UsingRabbitMq((ctx, busConfigurator) =>
                   {
                       busConfigurator.Host(configuration.GetConnectionString("RabbitMq"));
                   });
            });


            // services.AddMassTransit(x =>
            // {
            //     x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
            //     {
            //         config.UseHealthCheck(provider);
            //         config.Host(configuration.GetConnectionString("RabbitMq"));
            //     }));
            // });



            services.AddMassTransitHostedService();

            services.AddControllers();

            services.AddSwaggerDocumentation();

            services.AddDbContext<LibraryManagementContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            return services;
        }
        public static IApplicationBuilder UseApplicationServices(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}