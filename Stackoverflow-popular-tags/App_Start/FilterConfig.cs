using System.Web;
using System.Web.Mvc;

namespace Stackoverflow_popular_tags
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
