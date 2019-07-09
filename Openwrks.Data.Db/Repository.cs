using Microsoft.EntityFrameworkCore;
using Openwrks.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Openwrks.Data.Db
{

    public class Repository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        public OpenwrksContext DbContext { get; }
        private DbSet<T> DataSet => DbContext.Set<T>();

        DbContext IRepository<T>.DbContext { get; }

        public Repository(OpenwrksContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<T> All()
        {
            return DataSet.AsNoTracking();
        }

        public IQueryable<T> AllWithTracking()
        {
            return DataSet;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return DataSet.AsNoTracking().Where(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return DataSet.Any(expression);
        }

        public bool All(Expression<Func<T, bool>> expression)
        {
            return DataSet.All(expression);
        }

        public T Single(Expression<Func<T, bool>> expression)
        {
            return DataSet.AsNoTracking().Single(expression);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            return DataSet.AsNoTracking().SingleOrDefault(expression);
        }

        public T First(Expression<Func<T, bool>> expression)
        {
            return DataSet.AsNoTracking().First(expression);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return DataSet.AsNoTracking().FirstOrDefault(expression);
        }

        public void BulkUpdate(Expression<Func<T, bool>> @where, T partialEntity)
        {
            DataSet.Where(@where).Update(x => partialEntity);
        }

        public void Update(T entity)
        {
            var dbe = SingleOrDefault(x => x.Id == entity.Id);

            if (dbe == null)
                throw new ArgumentException($"An entity with ID {entity.Id} does not exist. Use Add(T entity) to insert new entities.");

            Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }

        public void Add(T entity)
        {
            var dbe = SingleOrDefault(x => x.Id == entity.Id);
            if (dbe != null)
                throw new ArgumentException($"An entity with ID {entity.Id} already exists. Use Update(T entity) to update existing entities.");

            DataSet.Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Add(entity);
        }

        public void Remove(T entity)
        {
            Attach(entity);
            DataSet.Remove(entity);
        }

        public void Remove(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Remove(entity);
        }

        public void Attach(T entity)
        {
            DataSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Unchanged;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Include(params Expression<Func<T, object>>[] includeProperties)
        {
            foreach (var include in includeProperties)
            {
                DataSet.Include(include);
            }
        }

        public T Create()
        {
            return new T();
        }




        #region Async

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await DataSet.AnyAsync(expression);
        }

        public async Task<bool> AllAsync(Expression<Func<T, bool>> expression)
        {
            return await DataSet.AllAsync(expression);
        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> expression)
        {
            return await DataSet.SingleAsync(expression);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await DataSet.SingleOrDefaultAsync(expression);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> expression)
        {
            return await DataSet.FirstAsync(expression);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await DataSet.FirstOrDefaultAsync(expression);
        }

        public async Task BulkUpdateAsync(Expression<Func<T, bool>> @where, T partialEntity)
        {
            await DataSet.Where(@where).UpdateAsync(x => partialEntity);
        }

        public async Task AddAsync(T entity)
        {
            await DataSet.AddAsync(entity);
        }

        public async Task AddAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                await AddAsync(entity);
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var dbe = await SingleOrDefaultAsync(x => x.Id == entity.Id);

            if (dbe == null)
                throw new ArgumentException($"An entity with ID {entity.Id} does not exist. Use Add(T entity) to insert new entities.");

            Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                await UpdateAsync(entity);
        }

        #endregion


    }
}
