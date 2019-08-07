using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Camc.MES53.Web.Areas.AppAreaName.Models.Layout;
using Camc.MES53.Web.Session;
using Camc.MES53.Web.Views;

namespace Camc.MES53.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameLogo
{
    public class AppAreaNameLogoViewComponent : MES53ViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;
        
        public AppAreaNameLogoViewComponent(
            IPerRequestSessionCache sessionCache
        )
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string logoSkin = null)
        {
            var headerModel = new LogoViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                LogoSkinOverride = logoSkin
            };
            
            return View(headerModel);
        }
    }
}
