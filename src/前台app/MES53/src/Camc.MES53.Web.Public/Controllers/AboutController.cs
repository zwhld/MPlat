using Microsoft.AspNetCore.Mvc;
using Camc.MES53.Web.Controllers;

namespace Camc.MES53.Web.Public.Controllers
{
    public class AboutController : MES53ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}