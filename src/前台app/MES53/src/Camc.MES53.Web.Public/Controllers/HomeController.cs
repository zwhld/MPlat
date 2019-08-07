using Microsoft.AspNetCore.Mvc;
using Camc.MES53.Web.Controllers;

namespace Camc.MES53.Web.Public.Controllers
{
    public class HomeController : MES53ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}