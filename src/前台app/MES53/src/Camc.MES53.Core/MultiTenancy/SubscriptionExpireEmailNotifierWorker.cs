using System;
using System.Diagnostics;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Abp.Timing;
using Camc.MES53.Authorization.Users;
using Camc.MES53.Configuration;

namespace Camc.MES53.MultiTenancy
{
    public class SubscriptionExpireEmailNotifierWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private const int CheckPeriodAsMilliseconds = 1 * 60 * 60 * 1000 * 24; //1 day
        
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly UserEmailer _userEmailer;

        public SubscriptionExpireEmailNotifierWorker(
            AbpTimer timer,
            IRepository<Tenant> tenantRepository,
            UserEmailer userEmailer) : base(timer)
        {
            _tenantRepository = tenantRepository;
            _userEmailer = userEmailer;

            Timer.Period = CheckPeriodAsMilliseconds;
            Timer.RunOnStart = true;

            LocalizationSourceName = MES53Consts.LocalizationSourceName;
        }

        protected override void DoWork()
        {
            var subscriptionRemainingDayCount = Convert.ToInt32(SettingManager.GetSettingValueForApplication(AppSettings.TenantManagement.SubscriptionExpireNotifyDayCount));
            var dateToCheckRemainingDayCount = Clock.Now.AddDays(subscriptionRemainingDayCount).ToUniversalTime();

            var subscriptionExpiredTenants = _tenantRepository.GetAllList(
                tenant => tenant.SubscriptionEndDateUtc != null &&
                          tenant.SubscriptionEndDateUtc.Value.Date == dateToCheckRemainingDayCount.Date &&
                          tenant.IsActive &&
                          tenant.EditionId != null
            );

            foreach (var tenant in subscriptionExpiredTenants)
            {
                Debug.Assert(tenant.EditionId.HasValue);
                try
                {
                    _userEmailer.TryToSendSubscriptionExpiringSoonEmail(tenant.Id, dateToCheckRemainingDayCount);
                }
                catch (Exception exception)
                {
                    Logger.Error(exception.Message, exception);
                }
            }
        }
    }
}
