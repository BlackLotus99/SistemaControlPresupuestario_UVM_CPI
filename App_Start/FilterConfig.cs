using System.Web;
using System.Web.Mvc;

namespace Sistema_UVM_Control_Presupuestario
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
