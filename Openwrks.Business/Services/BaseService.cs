using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Openwrks.Business.Contracts.Interfaces;
using Openwrks.Business.Models.Interfaces;
using Openwrks.Core.Enums;
using Openwrks.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Openwrks.Business.Services
{
    public abstract class BaseService<T, TObj, TCModel, TQModel> : IBaseService<T, TObj, TCModel, TQModel>
        where T : class, IEntity, new()
        where TObj : class, IDataModel, new()
        where TCModel : class, ICreateModel, new()
        where TQModel : class, IQueryModel, new()
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;
        public BaseService(IMapper mapper,
            IRepository<T> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

       
        public virtual async Task<IEnumerable<TObj>> GetItemsAsync(TQModel filters = null, DataMode mode = DataMode.Full)
        {
            var query = _repository.All();
            query = await DoFilterAsync(filters, query, mode);
            query = DoSorting(filters, query);
            query = query.DoPaging(filters);

            var dataList = _mapper.Map<IEnumerable<TObj>>(await query.ToListAsync());
            return dataList;
        }
        
        public virtual async Task<int> CountAsync(TQModel filters = null)
        {
            var query = _repository.All();
            query = await DoFilterAsync(filters, query, DataMode.Simple);
            return await query.CountAsync();
        }
        
        public virtual async Task<TObj> GetAsync(Guid identifier, TQModel filters = null)
        {
            var query = _repository.All();
            query = await DoFilterAsync(filters, query, DataMode.Full);
            var entity = await query.FirstOrDefaultAsync(x => x.Id == identifier);

            if (entity == null)
                return null;

            var dataModel = _mapper.Map<TObj>(entity);

            return dataModel;
        }
        
        public virtual async Task<bool> ExistsAsync(Guid identifier, TQModel filters = null)
        {
            var query = _repository.All();
            query = await DoFilterAsync(filters, query, DataMode.Full);
            var entity = await query.FirstOrDefaultAsync(x => x.Id == identifier);

            if (entity == null)
                return false;

            return true;
        }
        
        public virtual async Task<Guid> AddAsync(TCModel createModel)
        {
            var entity = _mapper.Map<T>(createModel);
            await _repository.AddAsync(entity);
            await _repository.CommitAsync();
            return entity.Id;
        }
        
        public virtual async Task UpdateAsync(Guid identifier, TCModel createModel, TQModel filters = null)
        {
            var query = _repository.AllWithTracking();
            query = await DoFilterAsync(filters, query, DataMode.Simple);
            var entity = await query.FirstOrDefaultAsync(x => x.Id == identifier);

            _mapper.Map(createModel, entity);

            await _repository.CommitAsync();
        }
        
        public virtual async Task DeleteAsync(Guid identifier, TQModel filters = null)
        {
            var query = _repository.All();
            query = await DoFilterAsync(filters, query, DataMode.Simple);
            var entity = await query.FirstOrDefaultAsync(x => x.Id == identifier);

            if (entity == null)
                return;

            _repository.Remove(entity);
            await _repository.CommitAsync();
        }

        public virtual IQueryable<T> DoFilter(TQModel filters, IQueryable<T> query, DataMode mode)
        {
            return query;
        }

        public virtual async Task<IQueryable<T>> DoFilterAsync(TQModel filters, IQueryable<T> query, DataMode mode)
        {
            return await Task.Run(() => DoFilter(filters, query, mode));
        }

        public virtual IQueryable<T> DoSorting(TQModel filters, IQueryable<T> query)
        {
            if (filters?.Paging != null)
            {
                var sortDesc = filters.Paging.SortDesc;

                switch (filters.Paging.SortBy?.ToLower())
                {
                    default:
                        query = sortDesc ? query.OrderByDescending(x => x.CreatedOn) : query.OrderBy(x => x.CreatedOn);
                        break;
                }
            }
            return query;
        }
    }
}
