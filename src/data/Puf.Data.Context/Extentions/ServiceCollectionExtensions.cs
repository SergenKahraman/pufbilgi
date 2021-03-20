using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Puf.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yms.Data.Context.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PufDbContext>(options => {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<DbContext, PufDbContext>();
        }
    }
}
