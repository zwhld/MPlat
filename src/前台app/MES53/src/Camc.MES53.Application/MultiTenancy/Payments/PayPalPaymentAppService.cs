using System.Threading.Tasks;
using Camc.MES53.MultiTenancy.Payments.Dto;
using Camc.MES53.MultiTenancy.Payments.Paypal;
using Camc.MES53.MultiTenancy.Payments.PayPal;
using Camc.MES53.MultiTenancy.Payments.PayPal.Dto;

namespace Camc.MES53.MultiTenancy.Payments
{
    public class PayPalPaymentAppService : MES53AppServiceBase, IPayPalPaymentAppService
    {
        private readonly PayPalGatewayManager _payPalGatewayManager;
        private readonly ISubscriptionPaymentRepository _subscriptionPaymentRepository;
        private readonly PayPalPaymentGatewayConfiguration _payPalPaymentGatewayConfiguration;

        public PayPalPaymentAppService(
            PayPalGatewayManager payPalGatewayManager,
            ISubscriptionPaymentRepository subscriptionPaymentRepository, 
            PayPalPaymentGatewayConfiguration payPalPaymentGatewayConfiguration)
        {
            _payPalGatewayManager = payPalGatewayManager;
            _subscriptionPaymentRepository = subscriptionPaymentRepository;
            _payPalPaymentGatewayConfiguration = payPalPaymentGatewayConfiguration;
        }

        public async Task ConfirmPayment(long paymentId, string paypalPaymentId, string paypalPayerId)
        {
            var payment = await _subscriptionPaymentRepository.GetAsync(paymentId);

            await _payPalGatewayManager.ExecutePaymentAsync(
                new PayPalExecutePaymentRequestInput(paypalPaymentId, paypalPayerId)
            );

            payment.Gateway = SubscriptionPaymentGatewayType.Paypal;
            payment.ExternalPaymentId = paypalPaymentId;
            payment.SetAsPaid();
        }

        public PayPalConfigurationDto GetConfiguration()
        {
            return new PayPalConfigurationDto
            {
                Environment = _payPalPaymentGatewayConfiguration.Environment,
                ClientId = _payPalPaymentGatewayConfiguration.ClientId,
                DemoUsername = _payPalPaymentGatewayConfiguration.DemoUsername,
                DemoPassword = _payPalPaymentGatewayConfiguration.DemoPassword
            };
        }

        public async Task CancelPayment(CancelPaymentDto input)
        {
            var payment = await _subscriptionPaymentRepository.GetByGatewayAndPaymentIdAsync(
                input.Gateway,
                input.PaymentId
            );

            payment.SetAsCancelled();
        }
    }
}