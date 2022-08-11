using APIOnion.Application.DTOs.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Application.Validations.Categories
{
    public class CategoryPostDtoValidation:AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(15);
        }
    }
}
