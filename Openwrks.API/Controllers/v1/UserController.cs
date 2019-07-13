using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Openwrks.Core.Enums;
using Openwrks.ViewModels.Models.Response.Generic;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Openwrks.ViewModels.Models.Request.Generic;
using Openwrks.ViewModels.Models.Response.Users;

namespace Openwrks.API.Controllers.v1
{
    [Route("api/account/")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IMapper mapper, ILogger log) : base(mapper, log)
        {
        }


        [HttpGet()]
        [Produces("application/json", Type = typeof(ListViewModel<UserViewModel>))]
        public async Task<IActionResult> GetUsers([FromQuery] UserListRequestModel filters, DataMode mode)
        {
            var userList = new List<UserViewModel>();

            userList.Add(new UserViewModel()
            {
                AccountNumber = "12345678",
                FirstName = "Peter",
                LastName = "Cranston"
            });



            return await GetListViewModel(userList, filters, userList.Count());
        }
    }
}
