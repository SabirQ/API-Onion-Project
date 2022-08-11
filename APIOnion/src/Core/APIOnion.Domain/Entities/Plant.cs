using APIOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Domain.Entities
{
    public class Plant:BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public List<PlantCategory> PlantCategories { get; set; }
    }
}
