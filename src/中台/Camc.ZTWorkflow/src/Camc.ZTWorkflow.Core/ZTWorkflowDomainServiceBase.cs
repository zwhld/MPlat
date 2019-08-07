using Abp.Domain.Services;

namespace Camc.ZTWorkflow
{
    public abstract class ZTWorkflowDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected ZTWorkflowDomainServiceBase()
        {
            LocalizationSourceName = ZTWorkflowConsts.LocalizationSourceName;
        }
    }
}
