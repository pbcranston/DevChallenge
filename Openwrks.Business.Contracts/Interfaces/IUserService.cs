using Openwrks.Business.Models.Models.User;
using Openwrks.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Openwrks.Business.Contracts.Interfaces
{
    public interface IUserService : IBaseService<User, UserDataModel, UserCreateModel, UserListQueryModel>
    {
        Task<UserDataModel> GetAsync(string accountNumber);

    }
}
