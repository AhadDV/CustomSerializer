using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.core.Resposittories;

namespace Task.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        private readonly TaskDbContext _context;

        public Repository(TaskDbContext context)
        {
            _context = context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll(params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (string item in includes)
            {
                query = query.Include(item);
            }

            return query;
        }

        public async System.Threading.Tasks.Task Save(TEntity entity)
        {
           await _context.Set<TEntity>().AddAsync(entity);
        }
    }
}
