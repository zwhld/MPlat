using Camc.MES53.MultiTenancy.Payments;

namespace Camc.MES53.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}