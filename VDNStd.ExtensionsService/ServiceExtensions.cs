﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VDNStd.ContractsService;
using VDNStd.LoggerService;

namespace VDNStd.ExtensionsService
{
    public static class ServiceExtensions
    {
        // CORS configuration
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        // IIS configuration
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        // Custom Logger configuration
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        //// SQL DB Context connection configuration
        //// With the help of the IConfiguration config parameter, you can access 
        //// the appsettings.json file and take all the data you need from it.
        //public static void ConfigureSQLDBContext(this IServiceCollection services, IConfiguration config)
        //{
        //    var sqlConnString = config["SQLConnString:DBConnAccountOwner"];
        //    services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(sqlConnString));
        //}

        //// Repository Wrapper configuration
        //public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        //{
        //    services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        //}
    }
}
