namespace Camc.MES53.MultiTenancy.Payments.Paypal
{
    public class PayPalExecutePaymentRequestInput
    {
        public string PaymentId { get; set; }

        public string PayerId { get; set; }

        public PayPalExecutePaymentRequestInput(string paymentId, string payerId)
        {
            PaymentId = paymentId;
            PayerId = payerId;
        }
    }
}