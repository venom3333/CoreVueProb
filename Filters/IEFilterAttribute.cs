using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vue2Spa.Filters
{
    public class IEFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
            if(Regex.IsMatch(userAgent, "MSIE [6-9]"))
            {
                context.Result = new ContentResult { Content = "Ваш браузер УСТАРЕЛ!" };
            }
        }
    }
}
