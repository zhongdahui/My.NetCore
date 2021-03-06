﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using My.NetCore.Model;

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

            context.Result = new JsonResult(ResultVM.Fail($"系统异常：{context.Exception.Message}"));
            context.ExceptionHandled = true;//异常已处理
        }
    }
}
