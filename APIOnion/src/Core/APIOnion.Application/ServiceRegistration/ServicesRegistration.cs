using APIOnion.Application.DTOs.Categories;
using APIOnion.Application.Mapping;

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Application.ServiceRegistration
{
    public static class ServicesRegistration
    {
        public static void ApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(opt => opt.AddProfile(new GeneralMap()));
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters().AddValidatorsFromAssemblyContaining<CategoryPostDto>();
        }
    }
}
