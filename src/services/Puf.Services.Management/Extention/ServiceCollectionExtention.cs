using Microsoft.Extensions.DependencyInjection;
using Puf.Services.Management.Abstraction;
using Puf.Services.Management.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puf.Services.Management.Extention
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddManagementService(this IServiceCollection services)
        {
            services.AddScoped<IWriterService, WriterService>();


            return services;
        }
    }
}
