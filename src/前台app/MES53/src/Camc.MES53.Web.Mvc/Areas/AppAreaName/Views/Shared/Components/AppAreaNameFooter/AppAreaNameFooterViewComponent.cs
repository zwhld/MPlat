using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Camc.MES53.Web.Areas.AppAreaName.Models.Layout;
using Camc.MES53.Web.Session;
using Camc.MES53.Web.Views;

namespace Camc.MES53.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameFooter
{
    public class AppAreaNameFooterViewComponent : MES53ViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameFooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool useWrapperDiv)
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                UseWrapperDiv = useWrapperDiv
            };

            return View(footerModel);
        }
    }
}
