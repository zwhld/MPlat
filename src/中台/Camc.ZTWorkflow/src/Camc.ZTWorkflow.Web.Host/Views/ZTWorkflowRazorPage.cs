using Abp.AspNetCore.Mvc.Views;

namespace Camc.ZTWorkflow.Web.Views
{
    public abstract class ZTWorkflowRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected ZTWorkflowRazorPage()
        {
            LocalizationSourceName = ZTWorkflowConsts.LocalizationSourceName;
        }
    }
}
