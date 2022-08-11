using APIOnion.Application.Interfaces.Repositories;
using APIOnion.Domain.Entities;
using APIOnion.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Persistance.Repositories
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context,DbSet<Category> dbSet):base(context,dbSet)
        {

        }
    }
}
