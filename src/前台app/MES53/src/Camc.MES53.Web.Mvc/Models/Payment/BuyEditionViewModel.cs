using System.Collections.Generic;
using Camc.MES53.Editions;
using Camc.MES53.Editions.Dto;
using Camc.MES53.MultiTenancy.Payments;
using Camc.MES53.MultiTenancy.Payments.Dto;

namespace Camc.MES53.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
