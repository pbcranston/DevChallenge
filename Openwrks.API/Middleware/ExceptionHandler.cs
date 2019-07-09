using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Openwrks.ViewModels.Models.Response;
using Openwrks.ViewModels.Models.Response.Generic;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Openwrks.API.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandler(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                #region Log error in Serilog

                try
                {
                    var routeValues = httpContext.GetRouteData().Values;
                    var action = routeValues["action"]?.ToString();
                    var controller = routeValues["controller"]?.ToString();

                    _logger.Error(ex,
                        ex.Message +
                        " [Controller: {Controller}| Action: {Action}| HttpMethod: {HttpMethod}| Path: {FullPath}]",
                        controller, action, httpContext.Request.Method, httpContext.Request.Path);
                }
                catch
                {
                    // Log generic error
                    _logger.Error(ex, ex.Message);
                }

                #endregion

                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Internal Server Error";

#if DEBUG
            message = exception.Message;
#endif


            await context.Response.WriteAsync(new ErrorViewModel()
            {
                Status = new ResponseViewModel()
                {
                    Status = HttpStatusCode.InternalServerError,
                    Message = message
                }
            }.ToString());
        }
    }
}
