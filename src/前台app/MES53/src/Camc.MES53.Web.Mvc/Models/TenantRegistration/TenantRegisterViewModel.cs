using Camc.MES53.Editions;
using Camc.MES53.Editions.Dto;
using Camc.MES53.MultiTenancy.Payments;
using Camc.MES53.Security;
using Camc.MES53.MultiTenancy.Payments.Dto;

namespace Camc.MES53.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
