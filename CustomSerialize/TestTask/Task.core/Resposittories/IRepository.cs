using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.core.Resposittories
{
   public interface IRepository<TEntity>
    {
        public System.Threading.Tasks.Task Save(TEntity entity);

        public IQueryable<TEntity> GetAll(params string[] includes);

        public int Commit();

        public Task<int> CommitAsync();


    }
}
