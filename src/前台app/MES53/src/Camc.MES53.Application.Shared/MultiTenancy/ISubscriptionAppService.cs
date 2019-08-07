using System.Threading.Tasks;
using Abp.Application.Services;

namespace Camc.MES53.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task UpgradeTenantToEquivalentEdition(int upgradeEditionId);

        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
