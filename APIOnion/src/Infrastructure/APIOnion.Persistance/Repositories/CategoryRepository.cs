using APIOnion.Domain.Entities;
using APIOnion.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Persistance.Repositories
{
    public class CategoryRepository:GenericRepository<Category>
    {
        public CategoryRepository(AppDbContext context):base(context)
        {

        }
    }
}
