using APIOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
    }
}
