using Microsoft.AspNetCore.Antiforgery;

namespace Camc.ZTWorkflow.Web.Controllers
{
    public class AntiForgeryController : ZTWorkflowControllerBase
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
