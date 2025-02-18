using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Context
{
    public static class DBServiceExtension
    {
        public static void AddDatabaseService(this IServiceCollection service, string connectionString)
                => service.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(connectionString, b => b.MigrationsAssembly("HealthChildTrackerAPI")));

    }
}
