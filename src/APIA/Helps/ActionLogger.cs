using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIA.Helps
{
    public class ActionLogger : IActionFilter
    {
        private readonly ILogger<ActionLogger> _logger;

        public ActionLogger(ILogger<ActionLogger> logger)
        {
            _logger = logger;

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var data = new
            {   
                User = context.HttpContext.User.Identity.Name,
                IP = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                HostName = context.HttpContext.Request.Host.ToString(),
                //AreaAccssed = context.HttpContext.Request
                Action = context.ActionDescriptor.DisplayName,
                TimeSpan = DateTime.Now
            };
            _logger.LogInformation(1, data.ToString());
            _logger.LogTrace("aeeee funcionou");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
