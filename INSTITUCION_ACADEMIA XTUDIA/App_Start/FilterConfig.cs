using System.Web;
using System.Web.Mvc;

namespace INSTITUCION_ACADEMIA_XTUDIA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
