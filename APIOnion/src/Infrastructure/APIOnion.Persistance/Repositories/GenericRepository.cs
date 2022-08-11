using APIOnion.Application.Interfaces.Repositories;
using APIOnion.Domain.Entities.Base;
using APIOnion.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context,DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }
        public async Task<T> AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
           _dbSet.Remove(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, params string[] includes)
        {
            IQueryable<T> query = expression is null ? _dbSet.AsQueryable() : _dbSet.Where(expression);
            if (includes.Length!=0)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            T value = await _dbSet.FirstOrDefaultAsync(t=>t.Id==id);
            return value;
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Update(T entity, bool state)
        {
            if (state)
            {
                _dbSet.Attach(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Unchanged;
            }
        }

    }
}
