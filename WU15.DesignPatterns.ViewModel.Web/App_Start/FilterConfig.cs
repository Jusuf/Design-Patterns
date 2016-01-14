using System.Web;
using System.Web.Mvc;

namespace WU15.DesignPatterns.ViewModel.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
