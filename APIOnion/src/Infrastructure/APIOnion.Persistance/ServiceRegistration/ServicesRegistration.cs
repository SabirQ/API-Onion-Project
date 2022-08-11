using APIOnion.Application.Interfaces.Repositories;
using APIOnion.Persistance.Context;
using APIOnion.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Persistance.ServiceRegistration
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("Default")
             ,d => d.MigrationsAssembly("APIOnion.Persistance")));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPlantRepository, PlantRepository>();
        }
    }
}
