using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using My.NetCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.Message);
        }
    }
}
