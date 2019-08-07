using Abp.Domain.Services;

namespace Camc.MES53
{
    public abstract class MES53DomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected MES53DomainServiceBase()
        {
            LocalizationSourceName = MES53Consts.LocalizationSourceName;
        }
    }
}
