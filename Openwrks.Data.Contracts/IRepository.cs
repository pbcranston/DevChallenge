using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Openwrks.Data.Contracts
{
    public interface IRepository<T>
        where T : class, IEntity, new()
    {
        DbContext DbContext { get; }

        IQueryable<T> All();
        IQueryable<T> AllWithTracking();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        bool All(Expression<Func<T, bool>> expression);

        T Single(Expression<Func<T, bool>> expression);
        T SingleOrDefault(Expression<Func<T, bool>> expression);
        T First(Expression<Func<T, bool>> expression);
        T FirstOrDefault(Expression<Func<T, bool>> expression);


        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void BulkUpdate(Expression<Func<T, bool>> where, T partialEntity);

        void Add(T entity);
        void Add(IEnumerable<T> entities);

        void Remove(T entity);
        void Remove(IEnumerable<T> entities);
        void Attach(T entity);

        void Commit();

        void Include(params Expression<Func<T, object>>[] includeProperties);

        T Create();


        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<bool> AllAsync(Expression<Func<T, bool>> expression);
        Task<T> SingleAsync(Expression<Func<T, bool>> expression);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<T> FirstAsync(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task UpdateAsync(T entity);
        Task UpdateAsync(IEnumerable<T> entities);
        Task BulkUpdateAsync(Expression<Func<T, bool>> @where, T partialEntity);
        Task AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entities);
        Task CommitAsync();
    }
}
