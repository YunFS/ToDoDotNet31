using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByNameAsync(string name);
        Task<bool> AddAsync(T document);
        Task<bool> UpdateAsync(T document);
        Task<bool> DeleteAsync(int id);
    }
}
