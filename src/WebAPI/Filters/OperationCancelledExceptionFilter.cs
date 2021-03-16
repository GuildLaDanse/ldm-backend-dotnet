using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace LaDanse.WebAPI.Filters
{
    public class OperationCancelledExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger = Log.ForContext<OperationCancelledExceptionFilter>();

        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is OperationCanceledException)
            {
                _logger.Information("Request was cancelled");
                context.ExceptionHandled = true;
                context.Result = new StatusCodeResult(400);
            }
        }
    }
}