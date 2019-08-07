using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Camc.MES53.Web.Controllers;

namespace Camc.MES53.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize]
    public class WelcomeController : MES53ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}