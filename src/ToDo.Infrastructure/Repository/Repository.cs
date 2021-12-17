using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;
using ToDo.Infrastructure.DAL;

namespace ToDo.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private DbSet<T> _entities;
        public Repository(AppDbContext appDbcontext)
        {
            if (appDbcontext == null)
                throw new ArgumentNullException("EntitiesContext");

            _appDbContext = appDbcontext;
            _entities = appDbcontext.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> filter)
        {
            return await _entities.Where(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetByNameAsync(string name)
        {
            return await _entities.Where(x => x.Name == name).ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            var results = await SaveAsync();

            if (results)
                return true;

            return false;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _entities.Update(entity);

            var results = await SaveAsync();

            if (results)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = _entities.Where(x => x.Id == id).FirstOrDefault();

            if (entity is null)
                throw new ArgumentNullException("Null value");

            _entities.Remove(entity);
            var results = await SaveAsync();

            if (results)
                return true;

            return false;
        }

        public async Task<bool> SaveAsync()
        {
            var results = await _appDbContext.SaveChangesAsync();

            if (results > 0)
                return true;

            return false;
        }
    }
}
