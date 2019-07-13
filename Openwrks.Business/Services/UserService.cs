using Openwrks.Business.Models.Models.User;
using Openwrks.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Openwrks.Business.Contracts.Interfaces;
using AutoMapper;
using Openwrks.Data.Contracts;
using System.Linq;
using Openwrks.Core.Enums;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Openwrks.Business.Services
{
    public class UserService : BaseService<User, UserDataModel, UserCreateModel, UserListQueryModel>, IUserService
    {
        public UserService(IMapper mapper,
            IRepository<User> repository) : base(mapper, repository)
        {
        }
        
        public override async Task<IQueryable<User>> DoFilterAsync(UserListQueryModel filters, IQueryable<User> query, DataMode mode)
        {
            query = await base.DoFilterAsync(filters, query, mode);

            switch (mode)
            {
                case DataMode.Simple:
                    break;
                case DataMode.Full:
                    query = query
                        .Include(u => u.Bank);
                    break;
            }

            if (filters != null)
            {
                if (filters.BankId != Guid.Empty)
                    query = query.Where(b => b.BankId == filters.BankId); // Return only user from given bank
            }

            return query;
        }

        public override IQueryable<User> DoSorting(UserListQueryModel filters, IQueryable<User> query)
        {
            if (filters?.Paging != null)
            {
                var sortDesc = filters.Paging.SortDesc;

                switch (filters.Paging.SortBy?.ToLower())
                {
                    case "lastName":
                        query = sortDesc ? query.OrderByDescending(u => u.LastName) : query.OrderBy(u => u.LastName);
                        break;
                    default:
                        query = sortDesc ? query.OrderByDescending(u => u.CreatedOn) : query.OrderBy(u => u.CreatedOn);
                        break;
                }
            }
            return query;
        }
    }
    
}
