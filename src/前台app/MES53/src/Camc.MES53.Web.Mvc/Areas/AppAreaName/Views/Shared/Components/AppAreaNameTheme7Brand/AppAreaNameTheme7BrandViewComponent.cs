using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Camc.MES53.Web.Areas.AppAreaName.Models.Layout;
using Camc.MES53.Web.Session;
using Camc.MES53.Web.Views;

namespace Camc.MES53.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameTheme7Brand
{
    public class AppAreaNameTheme7BrandViewComponent : MES53ViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameTheme7BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
