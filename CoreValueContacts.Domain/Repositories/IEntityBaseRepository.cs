using CoreValueContacts.Domain.Entities.Core;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CoreValueContacts.Domain.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityBaseRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        IQueryable<T> All { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PaginatedList<T> Paginate(int pageIndex, int pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetSingle(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enitity"></param>
        void Delete(T enitity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void DeleteGraph(T entity);
    }
}
