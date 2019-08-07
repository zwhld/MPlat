using Camc.MES53.MultiTenancy.Payments.Stripe;

namespace Camc.MES53.Web.Controllers
{
    public class StripeController : StripeControllerBase
    {
        public StripeController(
            StripeGatewayManager stripeGatewayManager,
            StripePaymentGatewayConfiguration stripeConfiguration)
            : base(stripeGatewayManager, stripeConfiguration)
        {
        }
    }
}
