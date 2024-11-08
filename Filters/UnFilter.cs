using Microsoft.AspNetCore.Mvc.Filters;

namespace lr11.Filters
{
    public class UnFilter: IActionFilter
    {
        // Колекція для збереження унікальних користувачів
        private static HashSet<string> uniqueUsers = new HashSet<string>();

        public void OnActionExecuting(ActionExecutingContext context)
        {
         
            var userIp = context.HttpContext.Connection.RemoteIpAddress?.ToString();

            if (userIp != null)
            {
                // Додаємо IP-адресу в HashSet (це гарантує унікальність)
                uniqueUsers.Add(userIp);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
          
        }

    
        public static int GetUniqueUserCount()
        {
            return uniqueUsers.Count;
        }
    }
}

