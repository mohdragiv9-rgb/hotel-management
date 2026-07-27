using Microsoft.AspNetCore.Http;

namespace HotelManagement.Helpers
{
    public static class SessionHelper
    {
        public static bool IsLoggedIn(HttpContext context)
        {
            return context.Session.GetString("UserName") != null;
        }

        public static string GetRole(HttpContext context)
        {
            return context.Session.GetString("Role") ?? "";
        }
    }
}