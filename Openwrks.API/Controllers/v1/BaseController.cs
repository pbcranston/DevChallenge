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

        public async Task<IActionResult> GetListViewModel<T>(IEnumerable<T> viewModelList, IListRequestModel model, int totalCount, string message = null)
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

        public async Task<IActionResult> GetItemViewModel<T>(T viewModel, string message = null)
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
        
        public IActionResult GetNotFound(string message = null)
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
        public IActionResult GetBadRequest(string message = null, Exception ex = null)
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
        public IActionResult GetBadRequest<T>(T viewModel, string message = null)
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
