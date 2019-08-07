using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Camc.ZTWorkflow.Web.Controllers
{
    public class HomeController : ZTWorkflowControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Ui");
        }
    }
}
