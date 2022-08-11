using APIOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Domain.Entities
{
    public class PlantCategory:BaseEntity
    {
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
