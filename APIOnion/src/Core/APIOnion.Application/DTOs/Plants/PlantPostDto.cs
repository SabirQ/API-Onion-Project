using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Application.DTOs.Plants
{
    public class PlantPostDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public List<CategoryInPlantPostDto> Categories { get; set; }
    }
    public class CategoryInPlantPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
