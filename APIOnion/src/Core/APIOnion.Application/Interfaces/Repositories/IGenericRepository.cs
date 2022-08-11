using APIOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIOnion.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, params string[] includes);
        Task<T> GetById(int id);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
        void Update(T entity,bool state=true);

    }
}
