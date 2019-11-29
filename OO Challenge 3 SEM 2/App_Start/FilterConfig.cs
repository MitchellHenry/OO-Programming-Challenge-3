using System.Web;
using System.Web.Mvc;

namespace OO_Challenge_3_SEM_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
