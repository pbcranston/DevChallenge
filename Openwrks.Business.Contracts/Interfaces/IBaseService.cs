using Openwrks.Business.Models.Interfaces;
using Openwrks.Core.Enums;
using Openwrks.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Openwrks.Business.Contracts.Interfaces
{
    public interface IBaseService<T, TObj, TCModel, in TQModel>
        where T : class, IEntity, new()
        where TObj : class, IDataModel, new()
        where TCModel : class, ICreateModel, new()
        where TQModel : class, IQueryModel, new()
    {
        /// <summary>
        /// Returns a collection that meets ALL of the filter criteria set in the model.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="mode">Simple = return data for previews only. Full = return all data.</param>
        /// <returns></returns>
        Task<IEnumerable<TObj>> GetItemsAsync(TQModel filters = null, DataMode mode = DataMode.Full);

        /// <summary>
        /// Returns a count of items based on filters.
        /// Ignores paging.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        Task<int> CountAsync(TQModel filters = null);
        
        /// <summary>
        /// Returns a single TObj by Identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        Task<TObj> GetAsync(Guid identifier, TQModel filters = null);
        
        /// <summary>
        /// Checks if an entity exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Guid identifier, TQModel filters = null);
        
        /// <summary>
        /// Create an entity in the database.
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns></returns>
        Task<Guid> AddAsync(TCModel createModel);
        
        /// <summary>
        /// Update entity in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createModel"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid identifier, TCModel createModel, TQModel filters = null);
        
        /// <summary>
        /// Delete an entity from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid identifier, TQModel filters = null);

        /// <summary>
        /// Apply a filter to the given query.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="query"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        IQueryable<T> DoFilter(TQModel filters, IQueryable<T> query, DataMode mode);
        /// <summary>
        /// Apply a filter to the given query.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="query"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        Task<IQueryable<T>> DoFilterAsync(TQModel filters, IQueryable<T> query, DataMode mode);

        /// <summary>
        /// Apply sorting to the given query.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        IQueryable<T> DoSorting(TQModel filters, IQueryable<T> query);
    }
}
