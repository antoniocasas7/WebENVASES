using System.Web;
using System.Web.Mvc;

namespace WebApiJWT_Swagger
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
