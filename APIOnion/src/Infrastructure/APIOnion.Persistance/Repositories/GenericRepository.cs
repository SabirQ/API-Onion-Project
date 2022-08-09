using APIOnion.Application.Interfaces.Repositories;
using APIOnion.Domain.Entities.Base;
using APIOnion.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
           _context.Set<T>().Remove(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> values = await _context.Set<T>().ToListAsync();
            return values;
        }

        public async Task<T> GetById(int id)
        {
            T value = await _context.Set<T>().FirstOrDefaultAsync(t=>t.Id==id);
            return value;
        }
    }
}
