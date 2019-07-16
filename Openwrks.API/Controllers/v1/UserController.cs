using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Openwrks.Core.Enums;
using Openwrks.ViewModels.Models.Response.Generic;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Internal;
using Openwrks.ViewModels.Models.Request.Generic;
using Openwrks.ViewModels.Models.Response.Users;
using Openwrks.Business.Contracts.Interfaces;
using Openwrks.Business.Models.Models.User;
using Openwrks.ViewModels.Models.Request.Users;

namespace Openwrks.API.Controllers.v1
{
    [Route("api/user/")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Actions to perform on the user entity
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="log"></param>
        /// <param name="userService"></param>
        public UserController(IMapper mapper, ILogger log, IUserService userService) : base(mapper, log)
        {
            _userService = userService;
        }

        /// <summary>
        /// Return list of users
        /// </summary>
        /// <param name="model"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [HttpGet()]
        [Produces("application/json", Type = typeof(ListViewModel<UserViewModel>))]
        public async Task<IActionResult> GetUsers([FromQuery] UserListRequestModel model, DataMode mode = DataMode.Full)
        {
            var filters = Mapper.Map<UserListQueryModel>(model);

            var users = await _userService.GetItemsAsync(filters, mode);
            var totalCount = await _userService.CountAsync(filters);

            return await GetListViewModel(users, model, totalCount);
        }

        /// <summary>
        /// Return single user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetUser")]
        [Produces("application/json", Type = typeof(ItemViewModel<UserViewModel>))]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
                return GetNotFound();

            var userVm = Mapper.Map<UserViewModel>(user);

            return await GetItemViewModel(userVm);
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost()]
        [Produces("application/json", Type = typeof(ItemViewModel<UserCreateModel>))]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequestModel user)
        {
            if (user == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingAccount = await _userService.GetAsync(user.AccountNumber);
            if (existingAccount != null)
                return GetBadRequest(user, $"User with account number {user.AccountNumber} already exists.");
            
            var userDto = Mapper.Map<UserCreateModel>(user);

            var newUserId = await _userService.AddAsync(userDto);

            return await GetCreatedRequestModel(user, newUserId, "GetUser");
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserCreateRequestModel user)
        {
            if (user == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userExists = await _userService.ExistsAsync(id);
            if (!userExists)
                return GetNotFound();


            var userDto = Mapper.Map<UserCreateModel>(user);
            await _userService.UpdateAsync(id, userDto);

            return NoContent();
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces("application/json", Type = null)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var userExists = _userService.ExistsAsync(id);
            if (!(await userExists))
                return NotFound();

            await _userService.DeleteAsync(id);

            return NoContent();
        }
    }
}
