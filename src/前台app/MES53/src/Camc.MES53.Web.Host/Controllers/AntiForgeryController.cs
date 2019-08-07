using Microsoft.AspNetCore.Antiforgery;

namespace Camc.MES53.Web.Controllers
{
    public class AntiForgeryController : MES53ControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
