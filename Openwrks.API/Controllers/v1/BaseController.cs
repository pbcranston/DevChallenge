using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Openwrks.ViewModels.Interfaces;
using Openwrks.ViewModels.Models.Response.Generic;
using Serilog;

namespace Openwrks.API.Controllers.v1
{
    public class BaseController : ControllerBase
    {
        protected IMapper Mapper { get; }

        protected ILogger Log { get; }

        public BaseController(IMapper mapper, ILogger log)
        {
            Mapper = mapper;
            Log = log;
        }

        protected async Task<IActionResult> GetListViewModel<T>(IEnumerable<T> viewModelList, IListRequestModel model, int totalCount, string message = null)
        where T : class, new()
        {
            return Ok(new ListViewModel<T>
            {
                Data = viewModelList,
                Paging = new PagingViewModel
                {
                    CurrentPage = model.PageNumber,
                    ItemsPerPage = model.ItemsPerPage,
                    TotalItems = totalCount
                },
                Status = new ResponseViewModel
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                }
            });
        }

        protected async Task<IActionResult> GetItemViewModel<T>(T viewModel, string message = null)
            where T : class, new()
        {
            return Ok(new ItemViewModel<T>
            {
                Data = viewModel,
                Status = new ResponseViewModel
                {
                    Status = HttpStatusCode.OK,
                    Message = message
                }
            });
        }


        protected async Task<IActionResult> GetCreatedRequestModel<TCreateRM>(TCreateRM viewModel, Guid entityId, string route, string message = null)
            where TCreateRM : class, ICreateRequestModel, new()
        {
            viewModel.Id = entityId;
            return CreatedAtRoute(route, new { id = entityId }, new ItemViewModel<TCreateRM>
            {
                Data = viewModel,
                Status = new ResponseViewModel
                {
                    Status = HttpStatusCode.Created,
                    Message = message
                }
            });
        }


        protected IActionResult GetNotFound(string message = null)
        {
            return NotFound(new ErrorViewModel()
            {
                Status = new ResponseViewModel
                {
                    Status = HttpStatusCode.NotFound,
                    Message = message
                }
            });
        }
        protected IActionResult GetBadRequest(string message = null, Exception ex = null)
        {
            var displayMessage = message;
#if DEBUG
            displayMessage += " " + ex.Message;
#endif

            return BadRequest(new ErrorViewModel()
            {
                Status = new ResponseViewModel
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = displayMessage.Trim()
                }
            });
        }
        protected IActionResult GetBadRequest<T>(T viewModel, string message = null)
            where T : class, new()
        {
            return BadRequest(new ItemViewModel<T>
            {
                Data = viewModel,
                Status = new ResponseViewModel
                {
                    Status = HttpStatusCode.BadRequest,
                    Message = message
                }
            });
        }
    }
}
