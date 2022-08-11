using APIOnion.Application.DTOs.Plants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Application.Validations.Plants
{
    internal class PlantPostDtoValidation:AbstractValidator<PlantPostDto>
    {
        public PlantPostDtoValidation()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(30);
            RuleFor(p => p.Desc).NotEmpty().MaximumLength(300);
            RuleFor(p => p.SKU).NotEmpty().MaximumLength(6).MinimumLength(6);
            RuleFor(p => p.Price).NotEmpty().LessThanOrEqualTo(9999.99m).GreaterThanOrEqualTo(1);
        }
    }
}
