using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Helpers
{
    static public class UserHelper
    {
        static public string GetUserID(HttpContext httpContext)
        {
            string userID = null;
            if(httpContext.User != null)
            {
                userID = httpContext.User.Identity.Name;
            }
            return userID;
        }
    }
}
