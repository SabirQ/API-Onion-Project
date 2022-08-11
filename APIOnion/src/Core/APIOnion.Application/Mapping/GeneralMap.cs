using APIOnion.Application.DTOs.Categories;
using APIOnion.Application.DTOs.Plants;
using APIOnion.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Application.Mapping
{
    public class GeneralMap:Profile
    {
        public GeneralMap()
        {
            CreateMap<Category, CategoryItemDto>();
            CreateMap<Category, CategoryPostDto>().ReverseMap();
            CreateMap<Plant, PlantItemDto>();
            CreateMap<Plant, PlantPostDto>().ReverseMap();
        }
    }
}
