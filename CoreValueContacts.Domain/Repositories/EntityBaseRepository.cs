using CoreValueContacts.Domain.Entities.Core;
using CoreValueContacts.Domain.Infrastructure;
using CoreValueContacts.Domain.Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using CoreValueContacts.Domain.Entities;

namespace CoreValueContacts.Domain.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntity, new ()
    {
        private EntitiesContext dbContext;

        #region Properties

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected EntitiesContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }

        #endregion

        public EntityBaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        
        public virtual IQueryable<T> All
        {
            get { return GetAll(); }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbContext.Set<T>();

            foreach(var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual PaginatedList<T> Paginate(int pageIndex, int pageSize)
        {
            return GetAll().ToPaginatedList(pageIndex, pageSize);
        }

        public T GetSingle(Guid id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T,bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            DbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteGraph(T entity)
        {
            DbSet<T> dbSet = DbContext.Set<T>();
            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }
    }
}
