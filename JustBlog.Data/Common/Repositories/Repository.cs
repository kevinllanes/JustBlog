using JustBlog.Core.Common.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;

namespace JustBlog.Data.Common.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        private DbSet<TEntity> _set;

        public DbSet<TEntity> Set => _set ?? (_set = Context.Set<TEntity>());

        public Repository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }


        public TEntity FindById(int id)
        {
            return Set.Find(id);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = Context.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public  void Detach(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }
    }
}
