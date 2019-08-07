using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Camc.MES53.Authorization;
using Camc.MES53.Web.Controllers;

namespace Camc.MES53.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : MES53ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}