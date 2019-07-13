using Openwrks.Business.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openwrks.Business
{
    public static class QueryExtensions
    {
        public static IQueryable<T> DoPaging<T>(this IQueryable<T> query, IQueryModel filters)
        {
            if (filters?.Paging != null)
            {
                if (filters.Paging.PageNumber < 1) filters.Paging.PageNumber = 1;

                query = query.Skip((filters.Paging.PageNumber - 1) * filters.Paging.ItemsPerPage);
                if (filters.Paging.ItemsPerPage > 0)
                    query = query.Take(filters.Paging.ItemsPerPage);
            }
            return query;
        }
    }
}
