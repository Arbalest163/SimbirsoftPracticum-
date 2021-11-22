using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;

namespace Library.Persistence
{
    /// <summary>
    /// 2.4 Получение строки подключения к базе данных из файла конфигурации
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ILibraryDbContext>(provider =>
                provider.GetService<LibraryDbContext>());
            return services;
        }
    }
}
