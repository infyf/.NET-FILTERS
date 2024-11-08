using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace lr11.Filters
{
    public class LogFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var Name = context.ActionDescriptor.DisplayName;
       
            var timestamp = DateTime.Now;

      
            var lgMess = $"Method: {Name}, Time: {timestamp}\n";

            File.AppendAllText("log.txt", lgMess);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        
        }
    }
}
