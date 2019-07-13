using Openwrks.Business.Models.Models.User;
using Openwrks.Data.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Openwrks.Business.Contracts.Interfaces
{
    public interface IUserService : IBaseService<User, UserDataModel, UserCreateModel, UserListQueryModel>
    {
    }
}
