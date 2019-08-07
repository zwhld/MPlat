using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Camc.MES53.Web.Controllers
{
    public class HomeController : MES53ControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Ui");
        }
    }
}
