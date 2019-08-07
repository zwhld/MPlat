using Abp.AspNetCore.Mvc.Views;

namespace Camc.MES53.Web.Views
{
    public abstract class MES53RazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected MES53RazorPage()
        {
            LocalizationSourceName = MES53Consts.LocalizationSourceName;
        }
    }
}
