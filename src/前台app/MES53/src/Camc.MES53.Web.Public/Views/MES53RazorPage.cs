using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Camc.MES53.Web.Public.Views
{
    public abstract class MES53RazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MES53RazorPage()
        {
            LocalizationSourceName = MES53Consts.LocalizationSourceName;
        }
    }
}
