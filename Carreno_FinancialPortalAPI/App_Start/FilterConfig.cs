using System.Web;
using System.Web.Mvc;

namespace Carreno_FinancialPortalAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
