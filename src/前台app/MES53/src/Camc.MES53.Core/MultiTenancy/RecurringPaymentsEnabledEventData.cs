using Abp.Events.Bus;

namespace Camc.MES53.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}