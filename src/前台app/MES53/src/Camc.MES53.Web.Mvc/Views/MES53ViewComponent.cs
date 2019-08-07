using Abp.AspNetCore.Mvc.ViewComponents;

namespace Camc.MES53.Web.Views
{
    public abstract class MES53ViewComponent : AbpViewComponent
    {
        protected MES53ViewComponent()
        {
            LocalizationSourceName = MES53Consts.LocalizationSourceName;
        }
    }
}